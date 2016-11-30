using System.Linq;
using ErieGarbageOnline.Database;

namespace ErieGarbageOnline.Models
{
    class Dispute : Message
    {
        public int BillId { get; set; }

        public new bool CheckValidity()
        {
            return EGODatabase.Create().Bills().Any(bill => bill.BillId == BillId) && base.CheckValidity();
        }
    }
}
