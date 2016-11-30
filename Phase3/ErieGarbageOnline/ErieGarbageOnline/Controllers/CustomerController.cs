using System.Linq;
using System.Web.Mvc;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Models.DatabaseModels;
using ErieGarbageOnline.Utilities;

namespace ErieGarbageOnline.Controllers
{
    [Utilities.Filter(FilterType.Customer)]
    public class CustomerController : ShareController
    {
        private readonly EGODatabase _database = EGODatabase.Create();
        public override ActionResult Index()
        {
            var user = Session["User"] as LoginModel;
            if (user == null) return RedirectToAction("Index", "Login");

            var cust = _database.Customers.FirstOrDefault(customer => customer.Email.Equals(user.Email));
            if (cust == null) return RedirectToAction("Index", "Login");

            var model = new CustomerModel {Firstname = cust.Firstname, Lastname = cust.Lastname};

            return View(model);
        }
        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult MessageAdmin()
        {

            var user = Session["User"] as LoginModel;
            if (user == null) return RedirectToAction("Index", "Login");

            var cust = _database.Customers.FirstOrDefault(customer => customer.Email.Equals(user.Email));
            if (cust == null) return RedirectToAction("Index", "Login");

            var model = new CustomerModel {Firstname = cust.Firstname, Lastname = cust.Lastname};
            return View(model);
        }

        public ActionResult SendMessage(CustomerModel model)
        {
            var user = Session["User"] as LoginModel;
            if (user == null) return RedirectToAction("Index", "Login");

            var cust = _database.Customers.FirstOrDefault(customer => customer.Email.Equals(user.Email));
            if (cust == null) return RedirectToAction("Index", "Login");

            var message = new Message {MessageBody = model.MessageBody, MessageType = model.MessageType, CustomerId = cust.CustomerId};
            if (message.CheckValidity())
            {
                _database.Messages.Add(message);
                _database.SaveChanges();
                return Json("Message Sent Successfully");
            }
            return Json("Message failed");
        }

        public ActionResult CancelAccount()
        {
            return View();
        }
    }
}