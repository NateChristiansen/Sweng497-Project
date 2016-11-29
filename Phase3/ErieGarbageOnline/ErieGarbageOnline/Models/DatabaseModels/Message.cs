using System;
using System.Linq;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public abstract class Message : IDbItem
    {
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; } = DateTime.Now;
        public abstract bool CheckValidity();
    }

    public enum MessageType
    {
        PlainMessage,
        Complaint,
        Dispute,
        Suspension
    }
}