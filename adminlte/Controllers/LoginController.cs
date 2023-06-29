using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            // Perform login logic...

            // Set the layout for the pages after login
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";

            return RedirectToAction("DashboardV1", "Dashboard");
        }
    }
}