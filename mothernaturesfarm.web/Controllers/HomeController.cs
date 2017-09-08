using System.Web.Mvc;

namespace mothernaturesfarm.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OurStory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calendar()
        {
            return(View());
        }

        [HttpGet]
        public ActionResult Parties()
        {
            return (View());
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return (View());
        }

        [HttpGet]
        public ActionResult Location()
        {
            return (View());
        }
    }
}