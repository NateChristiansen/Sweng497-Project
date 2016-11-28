using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Models
{
    public class AdminModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Message> MessageList;
        public List<Customer> CustomerList;
        public List<Admin> AdminList;
    }
}