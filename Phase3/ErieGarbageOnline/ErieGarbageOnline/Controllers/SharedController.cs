using System.Windows;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views;

namespace ErieGarbageOnline.Controllers
{
    public abstract class SharedController
    {
        protected internal User User;
        internal readonly EGODatabase Database = EGODatabase.Create();

        public void Logout()
        {
            User = null;
            new LoginController();
        }
    }
}
