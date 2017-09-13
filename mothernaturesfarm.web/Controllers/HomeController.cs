using System.Web.Mvc;
using mothernaturesfarm.web.DataAccess;
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
        public ActionResult Coupons(int disabled = 0)
        {
            if (disabled > 0)
                return (View("CouponsDisabled"));

            //MNFData mnfData = new MNFData();
            //if (mnfData.CouponIsEnabled(1))
            //    return (View("Coupons", new VMCoupon()));

            //return (View("CouponsDisabled"));

            return (View("Coupons", new VMCoupon()));
        }

        [HttpPost]
        public ActionResult Coupons(VMCoupon vmCoupon)
        {
            CouponService cSrv = new CouponService();
            CouponRegistrationResult cRes = cSrv.RegisterMember(vmCoupon);
            if (cRes == CouponRegistrationResult.MissingRequiredData)
                return(View("Coupons", vmCoupon));
            if (cRes == CouponRegistrationResult.UnknownException)
                return(View("CouponsError"));

            return (View("CouponsRegistered", new VMCoupon()));
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
                return (View("PartyReservation", vmPartyReservation));
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
            return (View("TourReservation", new VMTourReservation()));
        }

        [HttpPost]
        public ActionResult TourReservation(VMTourReservation vmTourReservation)
        {            
            EmailNotificationServices enf = new EmailNotificationServices();
            SendNotificationResult sRes = enf.SendNotification(vmTourReservation);

            if (sRes == SendNotificationResult.MissingRequiredData)
                return (View("TourReservation", vmTourReservation));
            if (sRes == SendNotificationResult.UnknownException)
                return (View("TourReservationError"));

            return (View("TourReservationSent"));

        }
    }
}