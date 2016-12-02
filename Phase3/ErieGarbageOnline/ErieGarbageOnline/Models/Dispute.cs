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
            return EGODatabase.Create().Bills().Any(bill => bill.Id == BillId) && base.CheckValidity();
        }
    }
}
