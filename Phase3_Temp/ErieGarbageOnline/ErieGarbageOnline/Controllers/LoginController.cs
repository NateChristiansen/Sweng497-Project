using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Controllers
{
    public class LoginController
    {
        private LoginWindow view;
        private EGODatabase database = EGODatabase.Create();
        public LoginController()
        {
            view = new LoginWindow(this);
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
            }
        }
    }
}
