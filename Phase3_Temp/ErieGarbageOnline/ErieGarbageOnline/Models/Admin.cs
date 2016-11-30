﻿using System.Collections.Generic;

namespace ErieGarbageOnline.Models
{
    class Admin : DbItem
    {
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public override bool CheckValidity()
        {
            if (Firstname == null) return false;
            if (Lastname == null) return false;
            if (Email == null) return false;
            return true;
        }
        public List<Customer> CustomerList;
        public List<Admin> AdminList;
    }
}
