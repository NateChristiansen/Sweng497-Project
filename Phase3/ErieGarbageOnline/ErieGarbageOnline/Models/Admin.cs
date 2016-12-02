using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public class Admin : User
    {

        public override bool CheckValidity()
        {
            return base.CheckValidity();
        }
    }
}
