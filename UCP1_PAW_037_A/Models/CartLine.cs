using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_037_A.Models
{
    public partial class CartLine
    {
        public int CartLineId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
