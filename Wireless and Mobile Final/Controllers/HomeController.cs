using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wireless_and_Mobile_Final.Controllers
{
    public class HomeController : Controller
    {
        Random random = new Random();
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }


        public int GetInt() {
            Console.WriteLine("Recieved request");
            return random.Next();
        }
    }
}
