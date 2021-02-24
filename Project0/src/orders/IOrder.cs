
using System;
using System.Collections.Generic;
using Project0.Customers;
using Project0.Products;


namespace Project0.Orders
{
    public interface IOrder
    {
        int OrderId { get; set; }
        int CustomerId { get; set; }
        int LocationId { get; }
        DateTime OrderTime { get; set; }
        decimal OrderTotal { get; set; }

        List<OrderLine> OrderLines { get; set; }

        //Dictionary<int, int> GetAllOrderLines();
        KeyValuePair<int, int> GetOrderLine(int lineId);
    }
}
