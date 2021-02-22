
using System;
using System.Collections.Generic;
using Project0.Orders;

namespace Project0.Locations
{
    public interface ILocation
    {
        int LocationId { get; set; }
        int StoreNumber { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Phone { get; set; }

        List<IOrder> GetOrderHistory();
    }
}
