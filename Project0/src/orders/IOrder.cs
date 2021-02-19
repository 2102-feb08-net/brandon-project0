
using System;
using System.Collections.Generic;
using Project0.Customers;
using Project0.Products;


namespace Project0.Orders
{
    public interface IOrder
    {
        string Location { get; }
        ICustomer Customer { get; }
        DateTime OrderTime { get; }
        IProduct[] Products { get; }
    }
}
