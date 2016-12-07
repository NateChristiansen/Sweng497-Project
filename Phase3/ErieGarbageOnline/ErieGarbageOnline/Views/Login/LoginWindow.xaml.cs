using System.Windows;
using System.Windows.Input;
using ErieGarbageOnline.Controllers;
using ErieGarbageOnline.Views.Login;

namespace ErieGarbageOnline.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginController controller;
        public LoginWindow(LoginController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            controller.Login();
        }

        private void EmailField_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PasswordField.Focus();
        }

        private void PasswordField_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                controller.Login();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var r = new Register();
            r.Show();
        }
    }
}
