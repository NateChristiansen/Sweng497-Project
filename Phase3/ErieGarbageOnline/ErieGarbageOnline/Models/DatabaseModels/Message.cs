using System;
using System.Linq;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Message : IDbItem
    {
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public bool CheckValidity()
        {
            if (string.IsNullOrEmpty(MessageBody)) return false;
            if (!EGODatabase.Create().Customers.Any(customer => customer.CustomerId == CustomerId)) return false;
            return true;
        }
    }

    public enum MessageType
    {
        Message,
        Complaint,
        Dispute,
        Suspension
    }
}