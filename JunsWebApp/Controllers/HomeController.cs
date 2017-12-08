using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JunsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];
            ViewBag.Message = $"{controller}::{action}::{id}";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string contactPerson)
        {
            if (!string.IsNullOrEmpty(contactPerson))
            {
                ViewBag.Message = $"Please Contact {contactPerson} for more information";
            }
            else
                ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}