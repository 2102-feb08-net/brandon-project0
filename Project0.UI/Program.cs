using System;
using System.Collections.Generic;
using Project0.Data;

using Project0.Customers;
using Project0.Orders;

namespace Project0.UI
{
    public class Program
    {
        public static void Main()
        {
            using var dependencies = new Dependencies();
            
            IProject0Repository repository = dependencies.CreateRepository();
            RunUI(repository);
        }

        public static void RunUI(IProject0Repository repository)
        {
            //ICustomer customer = new Project0.Customers.Customer("Lani", "Becker", "1805 Highrise Road", "Mythopolis", null, "Hypothetican Republic", null, null, "lbecker@emailhost.net");
            //repository.AddCustomer(customer);
            //repository.Save();

            //IEnumerable<ICustomer> result = repository.GetCustomers();
            //
            //foreach(ICustomer c in result)
            //{
            //    Console.WriteLine(c.FirstName + " " + c.LastName);
            //}

            IEnumerable<IOrder> result = repository.GetOrders();
            foreach (IOrder o in result)
            {
                Console.WriteLine(o.OrderId);
                var lines = o.GetAllOrderLines();
                foreach (var pair in lines)
                {
                    Console.WriteLine(pair.Value.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
