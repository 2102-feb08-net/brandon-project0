using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Data
{
    public partial class Product
    {
        public Product()
        {
            InventoryLines = new HashSet<InventoryLine>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime? BestBy { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<InventoryLine> InventoryLines { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
