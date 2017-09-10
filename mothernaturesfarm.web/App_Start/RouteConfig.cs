using System.Web.Mvc;
using System.Web.Routing;

namespace mothernaturesfarm.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute("Activities", "Activities", new { Controller = "Home", Action = "Activities" });
            routes.MapRoute("Animals", "Animals", new { Controller = "Home", Action = "Animals" });
            routes.MapRoute("Calendar", "calendar", new { Controller = "Home", Action = "Calendar" });
            routes.MapRoute("Christmas", "christmas", new { Controller = "Home", Action = "Christmas" });
            routes.MapRoute("ContactUs", "contactus", new { Controller = "Home", Action = "ContactUs" });
            routes.MapRoute("Coupons", "coupons", new { Controller = "Home", Action = "Coupons" });
            routes.MapRoute("FuturePlans", "futureplans", new { Controller = "Home", Action = "FuturePlans" });
            routes.MapRoute("OurStory", "OurStory", new { Controller = "Home", Action = "OurStory" });
            routes.MapRoute("Location", "location", new { Controller = "Home", Action = "Location" });
            routes.MapRoute("Parties", "parties", new { Controller = "Home", Action = "Parties" });
            routes.MapRoute("PartyReservation", "partyreservation", new { Controller = "Home", Action = "PartyReservation" });
            routes.MapRoute("PumpkinPatch", "pumpkinpatch", new { Controller = "Home", Action = "PumpkinPatch" });
            routes.MapRoute("TourReservation", "tourreservation", new { Controller = "Home", Action = "TourReservation" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
