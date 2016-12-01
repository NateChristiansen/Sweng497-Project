using System;
using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public class Bill : DbItem
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public bool Unpaid { get; set; } = true;
        public override bool CheckValidity()
        {
            var db = EGODatabase.Create();
            if (db.Customers().All(c => c.Id != CustomerId)) return false;
            return Amount > 0;
        }
    }
}
