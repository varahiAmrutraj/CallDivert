using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string message)
        {
            // Call the SendMessage function from the SendMessages class
            adminlte.AdditionalClasses.SendMessages.SendMessage(message);

            // Optionally, you can redirect the user to another page after sending the message
            return RedirectToAction("Mssage", "Message");
        }
    }
}