using System.Web.Mvc;

namespace ErieGarbageOnline.Controllers
{
    public abstract class ShareController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
    }
}