using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Controllers
{
    public abstract class SharedController
    {
        protected User _user;

        public void Logout()
        {
            _user = null;
            Application.Current.Shutdown();
        }
    }
}
