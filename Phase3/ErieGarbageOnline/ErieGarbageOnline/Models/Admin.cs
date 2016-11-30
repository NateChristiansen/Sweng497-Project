using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public class Admin : User
    {

        public override bool CheckValidity()
        {
            if (Firstname == null) return false;
            if (Lastname == null) return false;
            if (Email == null) return false;
            return true;
        }
    }
}
