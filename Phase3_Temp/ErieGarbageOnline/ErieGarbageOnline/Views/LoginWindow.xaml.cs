using System.Windows;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var x = EGODatabase.Create();
            x.Customers();
        }
    }
}
