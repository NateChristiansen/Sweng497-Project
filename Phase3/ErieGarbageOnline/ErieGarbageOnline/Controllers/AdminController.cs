using System.Net.Mail;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    class AdminController : SharedController
    {
        private EGODatabase _database = EGODatabase.Create();
        private Admin admin;
        private AdminWindow view;

        public AdminController(Admin admin)
        {
            this.admin = admin;
            view = new AdminWindow();
            view.Show();

        }
        public void CreateAdmin(Admin newAdmin)
        {
            if (IsAdminValid(newAdmin))
            {
                // Add the admin to the database
                // save changes
                // Display confirmation
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


    }
}
