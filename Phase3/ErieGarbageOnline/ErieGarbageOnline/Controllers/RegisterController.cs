using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views.Login;

namespace ErieGarbageOnline.Controllers
{
    class RegisterController
    {
        private Register _view;
        private readonly EGODatabase _database;

        public RegisterController(Register register)
        {
            _view = register;
            _database = EGODatabase.Create();
        }

        public bool RegisterCustomer(Customer newCust)
        {
            return CustomerIsValid(newCust) && _database.AddCustomer(newCust);
        }

        private bool CustomerIsValid(Customer cust)
        {
            if (cust == null)
                return false;

            if (cust.CheckValidity() == false)
                return false;

            if (string.IsNullOrEmpty(cust.Firstname))
                return false;

            if (string.IsNullOrEmpty(cust.Lastname))
                return false;

            if (string.IsNullOrEmpty(cust.Email))
                return false;

            if (string.IsNullOrEmpty(cust.Password))
                return false;

            if (cust.IsSuspended)
                return false;

            return true;
        }
    }
}
