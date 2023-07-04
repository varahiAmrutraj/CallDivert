using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adminlte.Models;
using System.Data.Entity;

namespace adminlte.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly adminlte.CallDivertDBContext _dbContext;

        public ScheduleController()
        {
            _dbContext = new adminlte.CallDivertDBContext();
        }


        [HttpPost]
        public ActionResult SaveEvent(string title, DateTime start, DateTime end)
        {
            // Logic to save the event to the database or perform any other required actions
            // You can access the title, start, and end parameters here

            // Return a response indicating the success or failure of the operation
            return Json(new { success = true });
        }










        public ActionResult Index()
        {
            return View();
        }

        // GET: User
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                // Save the new user to the database
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();

                return RedirectToAction("List");
            }

            // If the model is not valid, return the view with validation errors
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            // Retrieve the user from the database using the provided ID
            User user = GetUserById(id);

            if (user == null)
            {
                // If the user is not found, return a suitable response (e.g., error view or redirect)
                return HttpNotFound();
            }

            // Pass the user to the view for editing
            return View(user);
        }

        // POST: User/Update
        [HttpPost]
        public ActionResult Update(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                // Perform the update operation in the database using the updatedUser object
                UpdateUser(updatedUser);

                // Optionally, you can redirect to a different page after successful update
                return RedirectToAction("List");
            }

            // If the model state is not valid, return the edit view with validation errors
            return View("Edit", updatedUser);
        }

        // Helper method to retrieve the user from the database based on the provided ID
        private User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        // Helper method to update the user in the database
        private void UpdateUser(User updatedUser)
        {
             _dbContext.Entry(updatedUser).State = EntityState.Modified;
             _dbContext.SaveChanges();
        }

        public ActionResult List()
        {
            var userList = _dbContext.Users.ToList();
            return View(userList);
        }

        public ActionResult Delete(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
            {
                // User not found, handle the error or redirect to an appropriate page
                return HttpNotFound();
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            // Redirect to the list view after successful deletion
            return RedirectToAction("List");
        }
    }
}