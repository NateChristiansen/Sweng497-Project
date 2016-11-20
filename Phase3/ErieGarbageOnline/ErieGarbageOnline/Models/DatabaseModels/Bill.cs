using System;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Bill : IDbItem
    {
        public int BillId { get; set; }
        public bool CheckValidity()
        {
            throw new NotImplementedException();
        }
    }
}