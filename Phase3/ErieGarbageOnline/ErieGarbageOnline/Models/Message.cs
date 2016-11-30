using System;
using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    abstract class Message : DbItem
    {
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Viewed { get; set; }
        public bool Responded { get; set; }
        public override bool CheckValidity()
        {
            if (EGODatabase.Create().Customers().All(c => c.Id != CustomerId)) return false;
            if (string.IsNullOrWhiteSpace(MessageBody)) return false;
            return true;
        }
    }
}
