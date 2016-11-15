using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErieGarbageOnline.Controllers
{
    public abstract class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
    }
}