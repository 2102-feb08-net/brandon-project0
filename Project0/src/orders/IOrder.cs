
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
        int LocationId { get; set; }
        DateTime OrderTime { get; set; }
        decimal OrderTotal { get; set; }

        Dictionary<IProduct, int> GetAllOrderLines();
        (IProduct, int) GetOrderLine(int lineId);
    }
}
