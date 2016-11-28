using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Models
{
    public class CustomerModel
    {
        public List<string> MessageTypes = Enum.GetNames(typeof(MessageType)).ToList();
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}