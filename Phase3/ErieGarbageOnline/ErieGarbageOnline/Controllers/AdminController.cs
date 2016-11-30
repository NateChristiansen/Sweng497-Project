
using System.Linq;
using System.Web.Mvc;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;
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
<<<<<<< HEAD
            var newAdmin = new Admin() {Email = admin.Email, Password = admin.Password, Firstname = admin.Firstname, Lastname = admin.Lastname};
            
=======
            var newAdmin = new Admin {Email = admin.Email, Firstname = admin.Firstname, Lastname = admin.Lastname};

>>>>>>> 64dae96034b0e486bffa0a3727a32467c09858c2
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
            if (newAdmin.Firstname == null || newAdmin.Lastname == null || newAdmin.Email == null)
                return false;

            if (_database.Admins.Any(admin => admin.Email.Equals(newAdmin.Email)))
                return false;

            if (_database.Customers.Any(customer => customer.Email.Equals(newAdmin.Email)))
                return false;

            if (!newAdmin.Email.Contains("@"))
                return false;

            if (newAdmin.Password.Equals(""))
                return false;

            return true;

        }

        /// <summary>
        /// Check 
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCustomerAccountsW()
        {
            var custList = _database.Customers.ToList();

        }

        // moves to the admin creation page
        public ActionResult AdminCreation()
        {
            return View();
        }

        // moves to admin messaging center
        public ActionResult MessagingCenter()
        {
            return View();
        }

        // moves to customer view
        public ActionResult DuePayments()
        {
            return View();
        }

        // return home
        public override ActionResult Index()
        {
            return View();
        }

    }
}