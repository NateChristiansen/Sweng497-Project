using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Controllers
{
    class CustomerController : SharedController
    {
        public CustomerController(Customer customer)
        {
            this._user = customer;
        }
    }
}
