using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Controllers
{
    public class LoginController
    {
        private Views.LoginWindow view;
        private EGODatabase database = EGODatabase.Create();
        public LoginController()
        {
            view = new Views.LoginWindow(this);
            view.Show();
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
            view.label3.Content = "Username or password incorrect.";
        }
    }
}
