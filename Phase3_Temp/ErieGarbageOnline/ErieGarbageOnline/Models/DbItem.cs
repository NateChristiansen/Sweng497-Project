using System;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    abstract class DbItem
    {
        public int Id { get; set; }
        public abstract bool CheckValidity();
    }
}
