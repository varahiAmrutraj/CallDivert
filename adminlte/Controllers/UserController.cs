using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adminlte.Models;
using System.Data.Entity;
using Npgsql;
using System.EnterpriseServices.Internal;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Text;

namespace adminlte.Controllers
{
    public class UserController : Controller
    {
        private readonly adminlte.DBContext _dbContext;

        public UserController()
        {
            _dbContext = new adminlte.DBContext();
        }

        public ActionResult Index()
        {
            return RedirectToAction("List","User");
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
                string insertQuery = String.Format("INSERT INTO public.\"Users\" (\"Name\", \"WhatsappNumber\", \"Phone\") VALUES('{0}','{1}','{2}')", 
                                    model.Name, 
                                    model.WhatsappNumber, 
                                    model.Phone);
                _dbContext.ExecuteNonQuery(insertQuery);
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

                string updateQuery = String.Format("UPDATE public.\"Users\" SET \"Name\" = '{0}', \"WhatsappNumber\" = '{1}', \"Phone\" = '{2}' WHERE \"Id\" = {3}", 
                                        updatedUser.Name, 
                                        updatedUser.WhatsappNumber, 
                                        updatedUser.Phone,
                                        updatedUser.Id);
                _dbContext.ExecuteNonQuery(updateQuery);
                return RedirectToAction("List");
            }

            // If the model state is not valid, return the edit view with validation errors
            return View("Edit", updatedUser);
        }

        // Helper method to retrieve the user from the database based on the provided ID
        private User GetUserById(int id)
        {
            DataTable data = _dbContext.ExecuteQuery("select * from Public.\"Users\" where \"Id\" = " + id);
            if (data.Rows.Count > 0)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(data.Rows[0]["Id"]),
                    Name = data.Rows[0]["Name"].ToString(),
                    WhatsappNumber = data.Rows[0]["WhatsAppNumber"].ToString(),
                    Phone = data.Rows[0]["Phone"].ToString()
                };

                return user;
            }
            return new User();
        }

        // Helper method to update the user in the database
        private void UpdateUser(User updatedUser)
        {
             //_dbContext.Entry(updatedUser).State = EntityState.Modified;
             //_dbContext.SaveChanges();
        }

        public ActionResult List()
        {
            DataTable data = _dbContext.ExecuteQuery("select * from Public.\"Users\"");
            var userList = new List<User>();

            foreach (DataRow row in data.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    WhatsappNumber = row["WhatsAppNumber"].ToString(),
                    Phone = row["Phone"].ToString()
                };
                userList.Add(user);
            }
            return View(userList);
        }

        public ActionResult Delete(int id)
        {
            string deleteQuery = String.Format("DELETE FROM public.\"Users\" WHERE \"Id\" = {0}", id);
            _dbContext.ExecuteNonQuery(deleteQuery);

            // Redirect to the list view after successful deletion
            return RedirectToAction("List");
        }
    }
}