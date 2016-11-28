using System.Web.Mvc;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;

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