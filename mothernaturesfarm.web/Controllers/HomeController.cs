using System.Web.Mvc;
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