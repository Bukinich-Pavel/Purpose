using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string NameItem { get; set; }
        public string Tags { get; set; }
        public int integer1 { get; set; }
        public int integer2 { get; set; }
        public int integer3 { get; set; }
        public string string1 { get; set; }
        public string string2 { get; set; }
        public string string3 { get; set; }
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }
        public DateTime data1 { get; set; }
        public DateTime data2 { get; set; }
        public DateTime data3 { get; set; }
        public bool checkbox1 { get; set; }
        public bool checkbox2 { get; set; }
        public bool checkbox3 { get; set; }

        public int? CollectId { get; set; }

    }

    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Tags == y.Tags;
        }

        public int GetHashCode([DisallowNull] Item obj)
        {
            return 0;
        }

    }
}
