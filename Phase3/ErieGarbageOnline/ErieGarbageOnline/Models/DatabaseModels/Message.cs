using System;
using System.Linq;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public abstract class Message : IDbItem
    {
        public int MessageId { get; set; }
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public bool Viewed { get; set; }
        public bool Responded { get; set; }

        public bool CheckValidity()
        {
            if (!EGODatabase.Create().Customers.Any(c => c.CustomerId == CustomerId)) return false;
            if (string.IsNullOrWhiteSpace(MessageBody)) return false;
            return true;
        }
    }

    public enum MessageType
    {
        Complaint,
        Dispute,
        Suspension
    }
}