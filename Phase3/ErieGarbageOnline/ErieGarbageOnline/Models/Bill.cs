﻿using System;
using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public class Bill : DbItem
    {
        public int CustomerId { get; set; }
        public DateTime DateDue { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public override bool CheckValidity()
        {
            var db = EGODatabase.Create();
            if (db.Customers().All(c => c.Id != CustomerId)) return false;
            return Amount > 0;
        }
    }
}
