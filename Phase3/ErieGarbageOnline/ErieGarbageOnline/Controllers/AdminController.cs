using System.Web.Mvc;
using ErieGarbageOnline.Utilities;

namespace ErieGarbageOnline.Controllers
{
    [Utilities.Filter(FilterType.Admin)]
    public class AdminController : ShareController
    {
        public override ActionResult Index()
        {
            throw new System.NotImplementedException();
        }
    }
}