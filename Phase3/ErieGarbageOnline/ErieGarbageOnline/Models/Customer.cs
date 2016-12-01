using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public class Customer : User
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public override bool CheckValidity()
        {
            if (Address == null) return false;
            if (City == null) return false;
            if (State == null) return false;
            if (Country == null) return false;
            if (PostalCode == null) return false;
            return base.CheckValidity();
        }
    }
}
