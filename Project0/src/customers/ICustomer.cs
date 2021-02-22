
using System;
using System.Collections.Generic;
using Project0.Orders;

namespace Project0.Customers
{
    public interface ICustomer
    {
        int CustomerId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Address { get; }
        string City { get; }
        string State { get; }
        string Country { get; }
        string PostalCode { get; }
        string Phone { get; set; }
        string Email { get; set; }

        List<IOrder> GetOrderHistory();

        void SetFullAddress(string address, string city, string country, string state = "", string postalcode = "");
    }
}
