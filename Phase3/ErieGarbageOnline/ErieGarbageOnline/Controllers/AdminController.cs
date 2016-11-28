
using System.Linq;
using System.Web.Mvc;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;
﻿using System.Web.Mvc;
using ErieGarbageOnline.Utilities;

namespace ErieGarbageOnline.Controllers
{
    [Utilities.Filter(FilterType.Admin)]
    public class AdminController : ShareController
    {

        private readonly EGODatabase _database = EGODatabase.Create();

        /// <summary>
        /// Creates a new admin user to add to the database
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public ActionResult CreateNewAdmin(AdminModel admin)
        {
            // create admin from front end model
            var newAdmin = new Admin() {Email = admin.Email, Firstname = admin.Firstname, Lastname = admin.Lastname};

            if (AuthenticateNewAdmin(newAdmin))
            {
                _database.Admins.Add(newAdmin);
                _database.SaveChanges();
                return Json("Admin successfully authenticated and added to DB.");
            }

            return Json("admin could not be authenticated and not added to DB.");
        }

        /// <summary>
        /// Checks to see if a new admin is valid
        /// </summary>
        /// <param name="newAdmin"></param>
        /// <returns></returns>
        private bool AuthenticateNewAdmin(Admin newAdmin)
        {
            if (_database.Admins.Any(admin => admin.Email.Equals(newAdmin.Email)))
                return false;

            if (_database.Customers.Any(customer => customer.Email.Equals(newAdmin.Email)))
                return false;

            return true;

        }

        public override ActionResult Index()
        {
            return View();
        }

    }
}