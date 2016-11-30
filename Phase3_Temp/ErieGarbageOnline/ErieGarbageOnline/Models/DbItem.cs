using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErieGarbageOnline.Models
{
    [Serializable]
    abstract class DbItem
    {
        public int Id { get; set; }
        public abstract bool CheckValidity();
    }
}
