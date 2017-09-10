using System.Web.Mvc;
using mothernaturesfarm.web.Models;
using mothernaturesfarm.web.Services;
using mothernaturesfarm.web.ViewModels;

namespace mothernaturesfarm.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Activities()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult Animals()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult Calendar()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult Christmas()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return (View());
        }

        [HttpPost]
        public ActionResult ContactUs(VMContactUs vmContactUs)
        {
            EmailNotificationServices enf = new EmailNotificationServices();
            SendNotificationResult sRes = enf.SendNotification(vmContactUs);
            
            if (sRes == SendNotificationResult.UnknownException)
                return (View("ContactUsError"));

            return (View("ContactUsSent"));
        }
        [HttpGet]
        public ActionResult Coupons()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult FuturePlans()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult Location()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult OurStory()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Parties()
        {
            return (View());
        }
        [HttpGet]
        public ActionResult PartyReservation()
        {
            return (View("PartyReservation", new VMPartyReservation()));
        }
        [HttpPost]
        public ActionResult PartyReservation(VMPartyReservation vmPartyReservation)
        {
            EmailNotificationServices enf = new EmailNotificationServices();
            SendNotificationResult sRes = enf.SendNotification(vmPartyReservation);

            if (sRes == SendNotificationResult.MissingRequiredData)
                return (View("PartyReservation", new VMPartyReservation()));
            if (sRes == SendNotificationResult.UnknownException)
                return (View("PartyReservationError"));

            return (View("PartyReservationSent"));
        }
        [HttpGet]
        public ActionResult PumpkinPatch()
        {
            return(View());
        }
        [HttpGet]
        public ActionResult TourReservation()
        {
            return (View());
        }
    }
}