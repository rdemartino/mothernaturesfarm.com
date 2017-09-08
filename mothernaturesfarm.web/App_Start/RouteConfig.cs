using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mothernaturesfarm.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("OurStory", "Our-Story", new {Controller = "Home", Action = "OurStory"});
            routes.MapRoute("Calendar", "calendar", new { Controller = "Home", Action = "calendar" });
            routes.MapRoute("Parties", "parties", new { Controller = "Home", Action = "parties" });
            routes.MapRoute("ContactUs", "contactus", new { Controller = "Home", Action = "contactus" });
            routes.MapRoute("Location", "location", new { Controller = "Home", Action = "location" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
