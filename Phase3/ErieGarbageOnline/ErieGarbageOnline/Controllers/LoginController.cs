using System;
using System.Linq;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Test;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public class LoginController
    {
        private readonly LoginWindow view;
        private readonly EGODatabase database = EGODatabase.Create();
        public LoginController()
        {
            view = new LoginWindow(this);
            view.Show();
            //new FuzzTester().TestLogin(view, 1000, 0);
        }

        public void Login()
        {
            var email = view.EmailField.Text;
            var password = view.PasswordField.Password;
            var admin = database.Admins().FirstOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
            if (admin != null)
            {
                new AdminController(admin);
                view.Close();
                return;
            }
            var customer = database.Customers()
                .FirstOrDefault(c => c.Email.Equals(email) && c.Password.Equals(password));
            if (customer != null)
            {
                new CustomerController(customer);
                view.Close();
                return;
            }
            view.ErrorLabel.Content = "Username or password incorrect.";
        }
    }
}
