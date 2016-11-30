using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    class AdminController
    {
        private EGODatabase _database = EGODatabase.Create();
        private AdminWindow _adminView;

        public AdminController(AdminWindow adminView)
        {
            this._adminView = adminView;
            _adminView.Show();
        }
        public void CreateAdmin(Admin newAdmin)
        {
            if (IsAdminValid(newAdmin))
            {
                // Add the admin to the database
                // save changes
                // Display confirmation
            }
            else
            {
                // Display error
            }
        }

        private bool IsAdminValid(Admin newAdmin)
        {
            if (newAdmin.Email == null)
                return false;
            if (newAdmin.Password == null)
                return false;
            if (newAdmin.Firstname == null)
                return false;
            if (newAdmin.Lastname == null)
                return false;

            return true;
        }

        public void SendEmail(string receiver, string subject, string body)
        {
            string sender = "admin@ErieGarbageOnline.com";

            var mail = new MailMessage(sender, receiver);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = subject;
            mail.Body = body;

            try
            {
                client.Send(mail);
            }
            catch
            {
                // message that mail could not be sent
            }
        }

        public void DisplayDuePayments()
        {
            // get list of customers with due bills
            //var customersWithDuePayments = _database.Customers().ForEach()
            
        }


    }
}
