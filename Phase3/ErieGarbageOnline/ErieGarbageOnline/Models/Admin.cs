using System;
using System.Text.RegularExpressions;

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
