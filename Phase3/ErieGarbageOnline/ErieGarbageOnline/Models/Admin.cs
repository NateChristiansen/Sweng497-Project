﻿using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    class Admin : DbItem
    {
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
    }
}
