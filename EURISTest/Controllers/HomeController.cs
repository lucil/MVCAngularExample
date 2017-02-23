using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EURIS.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Benvenuto nell'applicativo di test per sviluppatori ASP.NET MVC di Gruppo EURIS.";

            return View();
        }
    }
}
