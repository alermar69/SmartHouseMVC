using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SmartHouseDll;
using SmartHouseMVC.Models;

namespace SmartHouseMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Session_Start()
        {
            House house = Session["home"] as House;

            if (house == null)
            {
                house = SerDesHouse.Read();
                if (house.Remote == null)
                {
                    house.Remote = new RemoteControl(new WebReader(house), null);
                }
                Session["home"] = house;
            }
        }      
    }
}
