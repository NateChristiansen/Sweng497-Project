using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    class Suspension : Message
    {
        public DateTime SuspensionEnds { get; set; }

        public new bool CheckValidity()
        {
            return DateTime.Now < SuspensionEnds && base.CheckValidity();
        }
    }
}
