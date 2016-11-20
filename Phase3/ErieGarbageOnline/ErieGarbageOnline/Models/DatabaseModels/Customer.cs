﻿using System;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Customer : IDbItem
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool CheckValidity()
        {
            throw new NotImplementedException();
        }
    }
}