using System;
using System.Collections.Generic;
using Project0.Data;

using Project0.Customers;
using Project0.Products;
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



            IEnumerable<IProduct> products = repository.GetProducts();
            foreach(IProduct p in products)
            {
                Console.WriteLine(p.Name);
            }

            //Dictionary<Products.Product, int> orderLines = new Dictionary<Products.Product, int>();
            //IOrder order = new Project0.Orders.Order(1, 1, new DateTime(), orderLines);
//
            //IEnumerable<IOrder> orders = repository.GetOrders();
            //foreach (IOrder o in orders)
            //{
            //    Console.WriteLine(o.OrderId + " " + o.CustomerId + " " + o.LocationId + " " + o.OrderTime + " " + o.OrderTotal);
            //    var lines = o.GetAllOrderLines();
            //    foreach (var pair in lines)
            //    {
            //        Console.WriteLine("    " + pair.Value.Value + " : " + pair.Value.Key.Name + " " + pair.Value.Key.BestBy + " " + pair.Value.Key.UnitPrice);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
