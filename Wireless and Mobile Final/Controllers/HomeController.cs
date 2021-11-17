using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wireless_and_Mobile_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
