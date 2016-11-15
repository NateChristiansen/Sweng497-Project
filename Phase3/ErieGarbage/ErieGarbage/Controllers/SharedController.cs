using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErieGarbage.Controllers
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