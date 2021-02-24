
using System;
using System.Collections.Generic;

using Project0.Products;


namespace Project0.Orders
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; }
    }
}