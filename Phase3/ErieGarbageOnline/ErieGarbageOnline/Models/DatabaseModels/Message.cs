using System;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Message : IDbItem
    {
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool CheckValidity()
        {
            throw new NotImplementedException();
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