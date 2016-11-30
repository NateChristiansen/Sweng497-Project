using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Controllers
{
    public class LoginController : Controller
    {
        private readonly EGODatabase _database = EGODatabase.Create();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            // if user is logged in, retrieve their info and return them to the correct page
            var model = Session["User"] as LoginModel;
            if (model != null)
            {
                // redirect to correct page
                return RedirectToAction("Index", model.Type.ToString());
            }

            // if session has been cleared, they must log back in
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(LoginModel model)
        {
            // create new model to prevent attackers from preseting information
            model = new LoginModel {Email = model.Email, Password = model.Password};
            var x = _database.Admins.ToList();
            if (AuthenticateUser(model))
            {
                return RedirectToAction("Index", model.Type.ToString());
            }
            ModelState.AddModelError("LoginError", "Error Message");
  
            return RedirectToAction("Index");
        }

        private bool AuthenticateUser(LoginModel model)
        {
            if (_database.Admins.Any(admin => admin.Email.Equals(model.Email) && admin.Password.Equals(model.Password)))
            {
                model.Authorized = true;
                model.Type = AccountType.Admin;
                FormsAuthentication.SetAuthCookie(model.Email, false);
                Session["User"] = model;
                return true;
            }
            if (
                _database.Customers.Any(
                    customer => customer.Email.Equals(model.Email) && customer.Password.Equals(model.Password)))
            {
                model.Authorized = true;
                model.Type = AccountType.Customer;
                FormsAuthentication.SetAuthCookie(model.Email, false);
                Session["User"] = model;
                return true;
            }

            return false;
        }
    }
}