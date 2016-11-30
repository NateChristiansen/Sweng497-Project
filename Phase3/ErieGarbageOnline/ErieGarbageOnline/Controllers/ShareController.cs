using System.Web.Mvc;

namespace ErieGarbageOnline.Controllers
{
    public abstract class ShareController : Controller
    {
        public abstract ActionResult Index();
        public ActionResult ViewPickupTime()
        {
            return null;
        }

        public ActionResult ViewAccountInformation()
        {
            return null;
        }
    }
}