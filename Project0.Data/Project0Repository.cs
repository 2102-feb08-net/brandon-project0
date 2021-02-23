using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NLog;

using Project0;
using Project0.Customers;
using Project0.Locations;
using Project0.Products;
using Project0.Orders;

namespace Project0.Data
{
    public class Project0Repository : IProject0Repository
    {
        private readonly Project0SQLDBContext _dbContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new repository given a suitable data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        public Project0Repository(Project0SQLDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }



        /// <summary>
        /// Get all customers with deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        public IEnumerable<ICustomer> GetCustomers(string search = null)
        {
            IQueryable<Customer> items = _dbContext.Customers;
            if (search != null)
            {
                items = items.Where(c => (c.FirstName + " " + c.LastName).Contains(search));
            }
            return items.Select(c => new Project0.Customers.Customer(
                c.FirstName, c.LastName, c.Address, c.City, c.State, c.Country, c.PostalCode, c.Phone, c.Email, c.CustomerId 
            ));
        }

        /// <summary>
        /// Add a new customer.
        /// </summary>
        public void AddCustomer(ICustomer customer)
        {
            if (customer.CustomerId != 0)
            {
                s_logger.Warn($"Customer to be added has an ID ({customer.CustomerId}) already: ignoring.");
            }

            s_logger.Info($"Adding Customer");

            // ID left at default 0
            Customer entity = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Email = customer.Email
            };
            _dbContext.Add(entity);
        }



        /// <summary>
        /// Get all products with optional name search string and deferred execution.
        /// </summary>
        /// <returns>The collection of all customers</returns>
        public IEnumerable<IProduct> GetProducts(string search = null)
        {
            IQueryable<Product> items = _dbContext.Products;
            if (search != null)
            {
                items = items.Where(p => p.Name.Contains(search));
            }
            return items.Select(p => new Project0.Products.Product(
                 p.Name, p.BestBy, p.UnitPrice, p.ProductId
            ));
        }




        /// <summary>
        /// Get all orders with option customerId search.
        /// </summary>
        public IEnumerable<IOrder> GetOrders(int? search = null)
        {
            IQueryable<Order> orders = _dbContext.Orders;
            if (search != null)
            {
                orders = orders.Where(o => o.CustomerId.Equals(search));
            }
            Dictionary<Project0.Products.Product, int> orderLines = _dbContext.OrderLines
                .Include(orderLines => orderLines.Product)
                .Select(o => o).ToDictionary(k => new Project0.Products.Product(
                    k.Product.Name,
                    k.Product.BestBy,
                    k.Product.UnitPrice,
                    k.Product.ProductId
                ), 
                v => v.Quantity);
            return orders.Select(o => new Project0.Orders.Order(
                    o.CustomerId, 
                    o.LocationId, 
                    o.OrderTime,
                    orderLines,
                    o.OrderId
                )
            );
        }


        /// <summary>
        /// Add new orders to store locations for customers.
        /// </summary>
        public void AddOrder(IOrder order)
        {
            if (order.OrderId != 0)
            {
                s_logger.Warn($"Order to be added has an ID ({order.OrderId}) already: ignoring.");
            }

            s_logger.Info($"Adding Order");

            // ID left at default 0
            Order entity = new Order
            {
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                OrderTime = order.OrderTime,
                OrderTotal = order.OrderTotal
            };
            _dbContext.Add(entity);
        }



        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}
