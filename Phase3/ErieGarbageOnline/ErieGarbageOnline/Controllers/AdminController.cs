using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class AdminController : SharedController
    {
        private EGODatabase _database = EGODatabase.Create();
        private AdminWindow view;

        public AdminController(Admin admin)
        {
            this._user = admin;
            view = new AdminWindow(this) {WelcomeLabel = {Content = "Welcome, " + admin.Email}};
            FillEmailReceiverBox();
            view.Show();

        }
        public void CreateAdmin(Admin newAdmin)
        {
            if (IsAdminValid(newAdmin))
            {
                // Add the admin to the database
                // save changes
                // Display confirmation
                _database.Admins().Add(newAdmin);
                _database.SaveChanges();
                MessageBox.Show("Admin " + newAdmin.Email + " has been added to the database.");
                Console.WriteLine(_database.Admins().Count);
            }
            else
            {
                MessageBox.Show("Could not add the admin to the database. Check to make sure fields are correct.");
            }

        }

        private bool IsAdminValid(Admin newAdmin)
        {
            if (!newAdmin.Email.Contains("@"))
                return false;
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
            string sender = _user.Email;

            var mail = new MailMessage(sender, receiver);
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("needsmtpnow@gmail.com", "ineedsmtp"),
                EnableSsl = true,
            };

            mail.Subject = subject;
            mail.Body = body;

            try
            {
                client.Send(mail);
                ClearEmailFields();
                MessageBox.Show("Message sent successfully");
            }
            catch (Exception e)
            {
                // message that mail could not be sent
                MessageBox.Show("Could not send email");
            }
        }

        private void ClearEmailFields()
        {
            view.SubjectBox.Clear();
            view.BodyBox.Clear();;
        }

        private void FillEmailReceiverBox()
        {
            var custList = _database.Customers();
            foreach (var customer in custList)
            {
                view.ReceiverBox.Items.Add(customer.Email);
            }
        }



    }
}
