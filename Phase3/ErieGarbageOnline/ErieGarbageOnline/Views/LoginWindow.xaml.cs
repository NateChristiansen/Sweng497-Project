using System.Windows;
using ErieGarbageOnline.Controllers;

namespace ErieGarbageOnline
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
    }
}
