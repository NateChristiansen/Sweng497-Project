using System;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class Admin : IDbItem
    {
        public int AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool CheckValidity()
        {
            throw new NotImplementedException();
        }
    }
}