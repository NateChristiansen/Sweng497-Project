﻿using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class AdminController : SharedController
    {
        private readonly AdminWindow _view;

        public AdminController(Admin admin)
        {
            User = admin;
            _view = new AdminWindow(this) {WelcomeLabel = {Content = "Welcome, " + admin.Email}};
            FillEmailReceiverBox();
            RefreshMessageList();
            GetDueBills();
            _view.Show();
        }

        public void CreateAdmin(Admin newAdmin)
        {
            if (IsAdminValid(newAdmin))
            {
                if (Database.AddAdmin(newAdmin))
                {
                    MessageBox.Show(_view, "Admin " + newAdmin.Email + " has been added to the database.");
                }
                else
                {
                    MessageBox.Show(_view, "User already exists in the database.");
                }
                ClearCreateAdminFields();
            }
            else
            {
                MessageBox.Show(_view, "Could not add the admin to the database. Check to make sure fields are correct.");
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

        public bool SendEmail(string receiver, string subject, string body)
        {

            if (!string.IsNullOrEmpty(receiver) && !string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(body))
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
                    return true;
                }
                catch
                {
                    // message that mail could not be sent
                    MessageBox.Show("Could not send email");
                    return false;
                }
            }

            MessageBox.Show("Could not send email");
            return false;

        }

        public void RespondToMessage(Message msg, RespondToMessageWindow msgResponseView)
        {
            if (msgResponseView.RespondToMsgBox == null || msgResponseView.RespondToMsgBox.Text.Equals(""))
            {
                MessageBox.Show(msgResponseView, "No message to send");
                msgResponseView.BringIntoView();
            }
            else
            {
                var customer = GetCustomerById(Convert.ToInt32(msgResponseView.MsgCustomerIdBox.Text));

                if (customer != null)
                {
                    string subject = "EGO: Response to your " + msgResponseView.MsgTypeBox;
                    string body = msgResponseView.RespondToMsgBox.Text;
                    if (SendEmail(customer.Email, subject, body))
                    {
                        Database.RespondToMessage(msg);
                        RefreshMessageList();
                        msgResponseView.Close();
                    }
                }
            }
            RefreshMessageList();
        }

        public void RefreshMessageList()
        {
            _view.MessageTable.ItemsSource = Database.AllMessages();
        }

        private Customer GetCustomerById(int custId)
        {
            return Database.Customers().FirstOrDefault(customer => custId == customer.Id);
        }

        private void ClearCreateAdminFields()
        {
            _view.EmailBox.Clear();
            _view.PasswordBox.Clear();
            _view.FirstNameBox.Clear();
            _view.LastNameBox.Clear();
        }

        private void ClearEmailFields()
        {
            _view.SubjectBox.Clear();
            _view.BodyBox.Clear();;
        }

        private void FillEmailReceiverBox()
        {
            var custList = Database.Customers();
            foreach (var customer in custList)
            {
                _view.ReceiverBox.Items.Add(customer.Email);
            }
        }

        public void GetDueBills()
        {
            _view.DuePayments.ItemsSource = Database.Bills().Where(bill => !bill.Paid);
        }
    }
}
