using System;
using System.Linq;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Bill : IDbItem
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool CheckValidity()
        {
            var db = EGODatabase.Create();
            if (!db.Customers.Any(c => c.CustomerId == CustomerId)) return false;
            return Amount > 0;
        }
    }
}