using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using mothernaturesfarm.web.DataAccess;
using mothernaturesfarm.web.Models;
using mothernaturesfarm.web.Services;

namespace mothernaturesfarm.web.Controllers
{
    public class CouponController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionService.MemberId == 0)
                return(File(new MemoryStream(), "image/jpg"));

            MNFData mnfData = new MNFData();
            Member mbr = mnfData.FindMember(SessionService.MemberId);

            if (mbr == null)
                return (File(new MemoryStream(), "image/jpg"));
            
            using (Stream fStream = System.IO.File.OpenRead(Server.MapPath(MNFConfiguration.CouponImageFilePath)))
            {
                using (Image cBaseImg = Image.FromStream(fStream))
                {
                    CouponService cSrv = new CouponService();
                    Image cImg = cSrv.RenderCouponImage(mbr, cBaseImg);
                    using (var ms = new MemoryStream())
                    {
                        cImg.Save(ms, ImageFormat.Jpeg);
                        return(File(ms.ToArray(), "image/jpeg"));
                    }
                }
            }
        }
    }
}