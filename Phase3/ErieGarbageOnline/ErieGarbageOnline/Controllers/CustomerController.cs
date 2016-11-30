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
            Message message;

            if (model.MessageType == MessageType.Complaint)
                message = new Complaint{MessageBody = model.MessageBody, CustomerId = cust.CustomerId};
            else if (model.MessageType == MessageType.Dispute)
                message = new Dispute{ MessageBody = model.MessageBody, CustomerId = cust.CustomerId, BillId = model.BillId};
            else if (model.MessageType == MessageType.Suspension)
                message = new Suspension
                {
                    MessageBody = model.MessageBody,
                    CustomerId = cust.CustomerId,
                    SuspensionEnds = model.SuspensionEnds
                };
            else
                return Json("Message failed");

            if (!message.CheckValidity()) return Json("Message failed");

            _database.Messages.Add(message);
            _database.SaveChanges();
            return Json("Message Sent Successfully");
        }

        public PartialViewResult Complaint()
        {
            return PartialView();
        }

        public PartialViewResult Suspension()
        {
            return PartialView();
        }

        public PartialViewResult Dispute()
        {
            return PartialView();
        }

        public ActionResult CancelAccount()
        {
            return View();
        }
    }
}