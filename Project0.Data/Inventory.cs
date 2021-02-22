using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.Data
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryLines = new HashSet<InventoryLine>();
        }

        public int InventoryId { get; set; }
        public int LocationId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<InventoryLine> InventoryLines { get; set; }
    }
}
