
using System;
using System.Collections.Generic;
using Project0.Customers;
using Project0.Products;


namespace Project0.Orders
{
    public interface IOrder
    {
        int OrderId { get; }
        int CustomerId { get; }
        int LocationId { get; }
        DateTime OrderTime { get; }
        decimal OrderTotal { get; }

        Dictionary<string, KeyValuePair<Product, int>> GetAllOrderLines();
        KeyValuePair<Product, int> GetOrderLine(int lineId);
    }
}
