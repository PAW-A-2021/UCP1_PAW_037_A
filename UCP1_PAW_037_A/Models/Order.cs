using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_037_A.Models
{
    public partial class Order
    {
        public Order()
        {
            CartLines = new HashSet<CartLine>();
        }

        public int OrderId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<CartLine> CartLines { get; set; }
    }
}
