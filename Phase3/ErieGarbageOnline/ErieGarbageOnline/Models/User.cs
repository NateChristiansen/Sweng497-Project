﻿using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public abstract class User : DbItem
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public override bool CheckValidity()
        {
            if (Email == null) return false;
            if (Password == null) return false;
            if (Firstname == null) return false;
            if (Lastname == null) return false;
            return true;
        }
    }
}