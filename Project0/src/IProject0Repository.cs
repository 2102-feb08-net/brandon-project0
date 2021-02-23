using System;
using System.Collections.Generic;
using Project0.Customers;
using Project0.Locations;
using Project0.Orders;
using Project0.Products;

namespace Project0
{
    public interface IProject0Repository
    {
        /// <summary>
        /// Get all customers with deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        IEnumerable<ICustomer> GetCustomers(string search = null);


        /// <summary>
        /// Place orders to store locations for customers.
        /// </summary>
        void PlaceOrder(ICustomer customer, ILocation location);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        void AddCustomer(string firstName, string lastName, string address, string city, string state, string country, string PostalCode, string phone, string email);
    }
}
