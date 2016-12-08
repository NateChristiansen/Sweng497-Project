using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using ErieGarbageOnline.Database;
using ErieGarbageOnline.Models;
using ErieGarbageOnline.Views.Login;

namespace ErieGarbageOnline.Controllers
{
    class RegisterController
    {
        private readonly Register _view;
        private readonly EGODatabase _database;

        public RegisterController(Register register)
        {
            _view = register;
            _database = EGODatabase.Create();
        }

        /// <summary>
        /// Validates text fields before customer object is even created
        /// </summary>
        /// <returns> Boolean specifying whether the input is acceptable </returns>
        private bool InputValidation()
        {
            bool isValid = true;

            SetAllBoxesToWhite();

            if (!_view.EmailBox.Text.Contains("@"))
            {
                _view.EmailBox.Background = Brushes.Gold;
                isValid = false;
            }

            if (!Regex.IsMatch(_view.FirstNameBox.Text, @"^[^0-9]+$"))
            {
                _view.FirstNameBox.Background = Brushes.Gold;
                isValid = false;
            }

            if (!Regex.IsMatch(_view.LastNameBox.Text, @"^[^0-9]+$"))
            {
                _view.LastNameBox.Background = Brushes.Gold;
                isValid = false;
            }

            if (!Regex.IsMatch(_view.StateBox.Text, @"^[^0-9]+$"))
            {
                _view.StateBox.Background = Brushes.Gold;
                isValid = false;
            }

            if (!Regex.IsMatch(_view.CountryBox.Text, @"^[^0-9]+$"))
            {
                _view.CountryBox.Background = Brushes.Gold;
                isValid = false;
            }

            foreach (var textBox in GetAllTextBoxes().Where(textBox => string.IsNullOrEmpty(textBox.Text)))
            {
                textBox.Background = Brushes.Gold;
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Collects all text boxes on the view and stores them in a list
        /// </summary>
        /// <returns> List of text boxes found on the view </returns>
        public IEnumerable<TextBox> GetAllTextBoxes()
        {
            var collection = _view.RegisterGrid.Children.OfType<TextBox>();

            return collection.ToList();
        }

        /// <summary>
        /// Inits text boxes on view to white
        /// </summary>
        private void SetAllBoxesToWhite()
        {
            foreach (var box in GetAllTextBoxes())
            {
                box.Background = Brushes.White;
            }
        }

        /// <summary>
        /// Adds a customer to the database
        /// </summary>
        /// <param name="newCust"></param>
        /// <returns> Boolean specifying whether action was accomplished or not </returns>
        public bool RegisterCustomer(Customer newCust)
        {
            return InputValidation() && CustomerIsValid(newCust) && _database.AddCustomer(newCust);
        }

        /// <summary>
        /// Checks the validity of the customer object
        /// </summary>
        /// <param name="cust"> Customer object created from inputs </param>
        /// <returns> Boolean specifying whether the customer info is valid or not </returns>
        private bool CustomerIsValid(Customer cust)
        {
            if (cust == null)
                return false;

            if (!cust.CheckValidity())
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
