using System;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Message : IDbItem
    {
        public int MessageId { get; set; }
        public bool CheckValidity()
        {
            throw new NotImplementedException();
        }
    }
}