using System.Collections.Generic;
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
        private AdminController _adminController;
        //public List<Message> msgList; 
        public AdminWindow(AdminController adminController)
        {
            this._adminController = adminController;
            InitializeComponent();
        }

        private void SubmitAdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Create admin from given information
            var admin = new Admin()
            {
                Email = this.EmailBox.Text,
                Password = this.PasswordBox.Password,
                Firstname = this.FirstNameBox.Text,
                Lastname = this.LastNameBox.Text
            };
            // attempt to add the admin to the DB
            _adminController.CreateAdmin(admin);
        }

        private void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            string receiver = ReceiverBox.SelectedItem.ToString();
            string subject = SubjectBox.Text;
            string body = BodyBox.Text;

            // send the email
            _adminController.SendEmail(receiver, subject, body);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _adminController.Logout();
        }
    }
}
