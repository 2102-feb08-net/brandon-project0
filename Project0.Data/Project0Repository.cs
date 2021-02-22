using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Project0;
using Project0.Customers;
using Project0.Locations;
using Project0.Orders;

namespace Project0.Data
{
    public class Project0Repository : IProject0Repository
    {
        private readonly Project0SQLDBContext _dbContext;

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
                items.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search));
            }
            return items.Select(c => new Project0.Customers.Customer(
                c.CustomerId, c.FirstName, c.LastName, c.Address, c.City, c.State, c.Country, c.PostalCode, c.Phone, c.Email
            ));
        }


    }
}
