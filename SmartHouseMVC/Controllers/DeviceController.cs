using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseDll;

namespace SmartHouseMVC.Controllers
{
    public class DeviceController : Controller
    {
        private House house;
        private string view;


        public ActionResult Command(string room, string device, string command)
        {
            house = Session["home"] as House;

            if (command.Contains("_plus"))
                command = command.Replace("_plus", "+");

            house.Remote.Reader.RoomData = room;
            house.Remote.Reader.DeviceData = device;
            house.Remote.Reader.CommandData = command;

            house.Remote.PushButton();

            Session["home"] = house;
            SaveHouse();
            GetView();

            return View(view, house);
        }
        public ActionResult LigthSelect(string room, string device, string command)
        {
            house = Session["home"] as House;

            ILight light = house.GetDevice(room, device) as ILight;
            if (light != null)
            {
                light.Brightness = (LightsState)Enum.Parse(typeof(LightsState), command);
                
            }

            house.Remote.PushButton();

            Session["home"] = house;
            SaveHouse();
            GetView();
            return View(view, house);
        }
 
        
        private void GetView()
        {
            if (Request.Cookies.Get("view") == null)
            {
                view = "~/Views/Home/Index.cshtml";
            }
            else
            {
                view = Request.Cookies.Get("view").Value;
            }
        }
        private void SaveHouse()
        {
            if (house != null)
            {
                SerDesHouse.Save(house);
            }
        }

	}
}