using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_037_A.Models
{
    public partial class Product
    {
        public Product()
        {
            CartLines = new HashSet<CartLine>();
        }

        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CartLine> CartLines { get; set; }
    }
}
