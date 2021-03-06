﻿using System;
using System.Windows;
using ErieGarbageOnline.Controllers;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly AdminController _adminController;
        //public List<Message> msgList; 
        public AdminWindow(AdminController adminController)
        {
            _adminController = adminController;
            InitializeComponent();
        }

        private void SubmitAdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Create admin from given information
            var admin = new Admin
            {
                Email = EmailBox.Text,
                Password = PasswordBox.Password,
                Firstname = FirstNameBox.Text,
                Lastname = LastNameBox.Text
            };
            // attempt to add the admin to the DB
            _adminController.CreateAdmin(admin);
        }

        private void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            string receiver;
            string subject;
            string body;

            try
            {
                receiver = ReceiverBox.SelectedItem.ToString();
                subject = SubjectBox.Text;
                body = BodyBox.Text;
            }
            catch
            {
                receiver = null;
                subject = null;
                body = null;
            }

            // send the email
            _adminController.SendEmail(receiver, subject, body);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _adminController.Logout();
            Close();
        }

        private void DueBillRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _adminController.GetDueBills();
        }
        
        private void MessageRespondButton_Click(object sender, RoutedEventArgs e)
        {
            var msg = this.MessageTable.SelectedItem as Message;
            var msgResponseView = new RespondToMessageWindow(msg, _adminController);
            msgResponseView.ShowDialog();
            _adminController.RefreshMessageList();
        }
    }
}
