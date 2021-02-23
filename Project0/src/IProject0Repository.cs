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
        /// Get all customers with optional name search string and deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        IEnumerable<ICustomer> GetCustomers(string search = null);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        void AddCustomer(ICustomer customer);



        /// <summary>
        /// Get all products with optional name search string and deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        IEnumerable<IProduct> GetProducts(string search = null);



        /// <summary>
        /// Get all orders with option customerId search and deferred execution.
        /// </summary>
        IEnumerable<IOrder> GetOrders(int? search = null);

        /// <summary>
        /// Add new orders to store locations for customers.
        /// </summary>
        void AddOrder(IOrder order);



        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
