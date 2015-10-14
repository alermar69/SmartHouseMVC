using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseDll;

namespace SmartHouseMVC.Controllers
{
    public class HomeController : Controller
    {
        private House house;
        private string view;


        public ActionResult Index()
        {
            house = Session["home"] as House;

            Response.Cookies.Add(new HttpCookie("view", "~/Views/Home/Index.cshtml"));
            return View(house);
        }

         public ActionResult AddTools()
        {
            house = Session["home"] as House;

            Response.Cookies.Add(new HttpCookie("view", "~/Views/Home/AddTools.cshtml"));
            return View(house);
        }
         public ActionResult AddRoom()
         {
             house = Session["home"] as House;
             GetView();

             house.Remote.Reader.RoomData = Request.Params["addRoom"];
             house.Remote.Reader.CommandData = "addRom";
             house.Remote.PushButton();

             SaveHouse();
             return View(view, house);
         }      
         public ActionResult AddDevice()
         {
             house = Session["home"] as House;
             GetView();

             house.Remote.Reader.RoomData = Request.Params["list_room"];
             house.Remote.Reader.DeviceData = Request.Params["addDevice"];

             house.Remote.Reader.CommandData = house.Remote.Commands.Values.
                 Where(c => c.Inform.Contains("Добавить " + Request.Params["list_device"])).
                 Select(c=>c.Name).First();

             house.Remote.PushButton();

             SaveHouse();
             return View(view, house);
         }
           

        public ActionResult DelTools()
        {
            house = Session["home"] as House;         

            Response.Cookies.Add(new HttpCookie("view", "~/Views/Home/DelTools.cshtml"));
            return View(house);
        }
        public ActionResult DelRoom()
        {
            house = Session["home"] as House;
            GetView();

            house.Remote.Reader.RoomData = Request.Params["list_room"];
            house.Remote.Reader.CommandData = "delRom";
            house.Remote.PushButton();

            SaveHouse();
            return View(view, house);
        }
        public ActionResult DelDevice()
        {
            house = Session["home"] as House;
            GetView();

            house.Remote.Reader.RoomData = Request.Params["list_room_device"];
            house.Remote.Reader.DeviceData = Request.Params["list_device"];

            house.Remote.Reader.CommandData = "delDev";

            house.Remote.PushButton();

            SaveHouse();
            return View(view, house);
        }
        public ActionResult Devices(string id)
        {
            house = Session["home"] as House;
            if (house == null)
                return Redirect("/Home/Index");


            ViewBag.RoomName = house.GetRoom(id).Name;

            ViewBag.Devices = new SelectList(house.GetRoom(id).Devices.Values, "Name", "Name");


           GetView();

            return View(view, house);
        }

        public ActionResult RedactTools()
        {
            house = Session["home"] as House;

            Response.Cookies.Add(new HttpCookie("view", "~/Views/Home/RedactTools.cshtml"));
            return View(house);
        }
        public ActionResult RedactRoom()
        {
            house = Session["home"] as House;
            GetView();

            house.ChangeNameRoom(Request.Params["list_room"], Request.Params["redactRoom"]);

            SaveHouse();
            return View(view, house);
        }
        public ActionResult RedactDevice()
        {
            house = Session["home"] as House;
            GetView();

            house.ChangeNameDevice(Request.Params["list_room_device"], Request.Params["list_device"], Request.Params["redactDevice"]);

            SaveHouse();
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