using System;
using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    class Dispute : Message
    {
        public int BillId { get; set; }

        public new bool CheckValidity()
        {
            var x = EGODatabase.Create().Bills();
            return x.Any(bill => bill.Id == BillId) && base.CheckValidity();
        }
    }
}
