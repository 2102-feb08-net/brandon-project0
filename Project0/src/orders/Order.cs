
using System;
using System.Collections.Generic;

using Project0.Products;


namespace Project0.Orders
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderTotal { get; set; }

        public List<OrderLine> OrderLines { get; set; }



        //public Dictionary<int, int> GetAllOrderLines()
        //{
        //    return new Dictionary<int, int>(_orderLines);
        //}

        public KeyValuePair<int, int> GetOrderLine(int lineId)
        {
            throw new NotImplementedException();
        }
    }
}