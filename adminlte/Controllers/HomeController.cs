using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult EditUser()
        {
            return View();
        }
        public ActionResult UsersList()
        {
            return View();
        }
        public ActionResult AddSchedule()
        {
            return View();
        }
        public ActionResult CallLog()
        {
            return View();
        }

        public ActionResult SMSLog()
        {
            return View();
        }
        public ActionResult CallLogUserWiseDetails()
        {
            return View();
        }
        public ActionResult SMSLogUserWiseDetails()
        {
            return View();
        }
        
    }
}