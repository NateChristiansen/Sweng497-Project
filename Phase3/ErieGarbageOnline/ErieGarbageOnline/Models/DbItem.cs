using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    public abstract class DbItem
    {
        public int Id { get; set; }
        public abstract bool CheckValidity();
    }
}
