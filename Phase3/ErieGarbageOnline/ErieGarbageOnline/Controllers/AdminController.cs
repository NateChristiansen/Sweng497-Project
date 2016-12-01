using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class AdminController : SharedController
    {
        private readonly AdminWindow view;

        public AdminController(Admin admin)
        {
            User = admin;
            view = new AdminWindow(this) {WelcomeLabel = {Content = "Welcome, " + admin.Email}};
            FillEmailReceiverBox();
            view.dataGrid.ItemsSource = Database.AllMessages();
            view.Show();

        }

        public void CreateAdmin(Admin newAdmin)
        {
            if (IsAdminValid(newAdmin))
            {
                if (Database.AddAdmin(newAdmin))
                {
                    MessageBox.Show("Admin " + newAdmin.Email + " has been added to the database.");
                }
                else
                {
                    MessageBox.Show("User already exists in the database.");
                }
                ClearCreateAdminFields();
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

        private void ClearCreateAdminFields()
        {
            view.EmailBox.Clear();
            view.PasswordBox.Clear();
            view.FirstNameBox.Clear();
            view.LastNameBox.Clear();
        }

        public void SendEmail(string receiver, string subject, string body)
        {
            string sender = User.Email;

            var mail = new MailMessage(sender, receiver);
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("needsmtpnow@gmail.com", "ineedsmtp"),
                EnableSsl = true
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
            var custList = Database.Customers();
            foreach (var customer in custList)
            {
                view.ReceiverBox.Items.Add(customer.Email);
            }
        }
    }
}
