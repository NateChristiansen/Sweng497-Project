using System;
using System.Collections.Generic;
using System.Linq;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Models
{
    public class CustomerModel
    {
        public List<string> MessageTypes = Enum.GetNames(typeof(MessageType)).ToList();
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public MessageType MessageType { get; set; }
        public int CustomerId { get; set; }
        public string MessageBody { get; set; }
        public int BillId { get; set; }
        public DateTime SuspensionEnds { get; set; }
    }
}