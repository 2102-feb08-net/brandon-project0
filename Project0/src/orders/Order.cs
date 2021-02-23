
using System;
using System.Collections.Generic;

using Project0.Products;


namespace Project0.Orders
{
    public class Order : IOrder
    {
        public int OrderId { get; }
        public int CustomerId { get; }
        public int LocationId { get; }
        public DateTime OrderTime { get; }
        public decimal OrderTotal { get; private set; }

        private Dictionary<string, KeyValuePair<Product, int>> _orderLines = new Dictionary<string, KeyValuePair<Product, int>>();



        public Order(int customerId, int locationId, DateTime orderTime, Dictionary<Product, int> orderLines, int orderId = 0)
        {
            OrderId = orderId;
            CustomerId = customerId > 0 ? customerId : throw new ArgumentException($"CustomerId must be greater than zero"); // Technically this should check DB for valid customer?
            LocationId = locationId > 0 ? locationId : throw new ArgumentException($"LocationId must be greater than zero"); // Technically this should check DB for valid location?
            OrderTime = orderTime;
            
            foreach (var pair in orderLines)
            {
                _orderLines.Add(pair.Key.Name, pair);
            }
        }


        public Dictionary<string, KeyValuePair<Product, int>> GetAllOrderLines()
        {
            return new Dictionary<string, KeyValuePair<Product, int>>(_orderLines);
        }

        public KeyValuePair<Product, int> GetOrderLine(int lineId)
        {
            throw new NotImplementedException();
        }
    }
}