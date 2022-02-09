using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose.Models
{
    public class ItemLike
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string NameUser { get; set; }
        public bool Like { get; set; }
    }
}
