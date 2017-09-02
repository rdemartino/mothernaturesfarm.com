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
        [Route("OurStory")]
        public ActionResult OurStory()
        {
            return View();
        }
    }
}