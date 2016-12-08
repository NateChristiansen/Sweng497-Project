using System.Windows;
using ErieGarbageOnline.Controllers;

namespace ErieGarbageOnline.Views.Login
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private RegisterController _controller;
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var cust = new Models.Customer()
            {
                Address = this.AddressBox.Text,
                City = this.CityBox.Text,
                Country = this.CountryBox.Text,
                State = this.StateBox.Text,
                Email = this.EmailBox.Text,
                Password = this.PasswordBox.Password,
                Firstname = this.FirstNameBox.Text,
                Lastname = this.LastNameBox.Text,
                PostalCode = this.PostalCodeBox.Text
            };

            _controller = new RegisterController(this);

            string msgBox = "Please check your entry and try submitting again.";

            if (_controller.RegisterCustomer(cust))
            {
                msgBox = "You have been successfully registed. Welcome to EGO!";
                MessageBox.Show(this, msgBox);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, msgBox);
            }


        }
    }

}
