using System.Linq;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Dispute : Message
    {
        public int BillId { get; set; }

        public new bool CheckValidity()
        {
            return EGODatabase.Create().Bills.Any(bill => bill.BillId == BillId) && base.CheckValidity();
        }
    }
}