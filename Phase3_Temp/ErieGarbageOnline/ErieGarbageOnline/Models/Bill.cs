using System;
using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    class Bill : DbItem
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool Unpaid { get; set; }
        public override bool CheckValidity()
        {
            var db = EGODatabase.Create();
            if (!db.Customers().Any(c => c.CustomerId == CustomerId)) return false;
            return Amount > 0;
        }
    }
}
