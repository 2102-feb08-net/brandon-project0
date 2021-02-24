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
            
            // "Lani", "Becker", "1805 Highrise Road", "Mythopolis", null, "Hypothetican Republic", null, null, "lbecker@emailhost.net"

            Console.WriteLine();
            Console.WriteLine(" Golly G General Stores Master Control Program ");
            Console.WriteLine("    Welcome, Authorized User!");
            Console.WriteLine();

            // Display main menu
            bool exit = false;
            do
            {
                Console.WriteLine(" (1) Display Customers");
                Console.WriteLine(" (2) Add Customer");
                Console.WriteLine(" (3) Display Products");
                Console.WriteLine(" (4) Display Orders");
                Console.WriteLine(" (5) Add Order");
                Console.WriteLine(" (6) Exit Program");
                Console.WriteLine();

                int selection = -1;
                do
                {
                    Console.Write("    Enter a menu selection by number: ");
                    if (Int32.TryParse(Console.ReadLine(), out selection))
                    {
                        if (selection < 1 || selection > 6)
                        {
                            Console.WriteLine("    Selection invalid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    Selection could not be parsed. Please enter a number between 1 and 6");
                        selection = -1;
                    }
                } while (selection < 1 || selection > 6);

                switch(selection)
                {
                    case 1:
                        DisplayCustomers(repository);
                        break;
                    case 2:
                        AddCustomer(repository);
                        break;
                    case 3:
                        DisplayProducts(repository);
                        break;
                    case 4:
                        DisplayOrders(repository);
                        break;
                    case 5:
                        AddOrder(repository);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        throw new ArgumentException();

                }

            } while (exit == false);
        }

        /// <summary>
        /// Write a list of customers to console with optional search-by-name.
        /// </summary>
        public static void DisplayCustomers(IProject0Repository repository)
        {
            Console.Write("    Enter a customer name to search for? (Y/N) : ");
            string doSearch = Console.ReadLine().ToLower();
            string search = null;
            if (doSearch == "y" || doSearch == "yes")
            {
                Console.Write("        ");
                search = Console.ReadLine();
            }
            Console.WriteLine();

            IEnumerable<ICustomer> result = repository.GetCustomers(search);
            foreach (ICustomer c in result)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName + " ; " + c.Address + ", " + c.City + " " + c.State + ", " + c.Country + " " + c.PostalCode + " ; " + c.Phone + " ; " +c.Email);
            }

            Console.WriteLine();
            Console.Write("   Press Enter to continue");
            Console.ReadLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Get new customer information from user and add to system.
        /// </summary>
        public static void AddCustomer(IProject0Repository repository)
        {
            // Get first name from user
            string firstName = null;
            do 
            {
                Console.Write("    Enter First Name: ");
                firstName = Console.ReadLine();
                if (firstName.Length < 2)
                {
                    firstName = null;
                }
            } while (firstName == null);

            // Get last name from user
            string lastName = null;
            do 
            {
                Console.Write("    Enter Last Name: ");
                lastName = Console.ReadLine();
                if (lastName.Length < 2)
                {
                    lastName = null;
                }
            } while (lastName == null);

            Console.Write("    Enter Address? (Y/N) : ");
            string doAddress = Console.ReadLine().ToLower();
            string address = null, city = null, state = null, country = null, postalCode = null;
            if (doAddress == "y" || doAddress == "yes")
            {
                Console.Write("    Enter Address: ");
                address = Console.ReadLine();
                // Check Address Format Here

                Console.Write("    Enter City: ");
                city = Console.ReadLine();
                // Check City Format Here

                Console.Write("    Enter State: ");
                state = Console.ReadLine();
                // Check State Format Here

                Console.Write("    Enter Country: ");
                country = Console.ReadLine();
                // Check Country Format Here

                Console.Write("    Enter Postal Code: ");
                postalCode = Console.ReadLine();
                // Check Postal Code Format Here

            }

            Console.Write("    Enter Phone Number? (Y/N) : ");
            string toPhone = Console.ReadLine().ToLower();
            string phone = null;
            if (toPhone == "y" || toPhone == "yes")
            {
                Console.Write("    Enter Phone Number: ");
                phone = Console.ReadLine();
                // Check Phone Number Format Here

            }

            string email = null;
            do
            {
                Console.Write("    Enter Email: ");
                email = Console.ReadLine();
                // Check Email Format Here

            } while (email == null);


            ICustomer customer = new Project0.Customers.Customer(firstName, lastName, address, city, state, country, postalCode, phone, email);
            repository.AddCustomer(customer);
            repository.Save();

            Console.WriteLine();
        }



        /// <summary>
        /// Write a list of products to console with optional search-by-name.
        /// </summary>
        public static void DisplayProducts(IProject0Repository repository)
        {
            Console.Write("    Enter a product name to search for? (Y/N) : ");
            string doSearch = Console.ReadLine().ToLower();
            string search = null;
            if (doSearch == "y" || doSearch == "yes")
            {
                Console.Write("        ");
                search = Console.ReadLine();
            }
            Console.WriteLine();

            IEnumerable<IProduct> products = repository.GetProducts(search);
            foreach (IProduct p in products)
            {
                Console.WriteLine(p.Name + " " + p.BestBy + " " + p.UnitPrice);
            }

            Console.WriteLine();
            Console.Write("   Press Enter to continue");
            Console.ReadLine();
            Console.WriteLine();
        }



        /// <summary>
        /// Write a list of orders to console with optional search-by-customerId.
        /// </summary>
        public static void DisplayOrders(IProject0Repository repository)
        {
            Console.Write("    Enter a CustomerId to filter orders? (Y/N) : ");
            string doSearch = Console.ReadLine().ToLower();
            int? search = null;
            if (doSearch == "y" || doSearch == "yes")
            {
                do
                {
                    Console.Write("        ");
                    try
                    {
                        search = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        search = null;
                    }
                } while (search == null);
                
            }

            IEnumerable<IOrder> orders = repository.GetOrders(search);
            foreach (IOrder o in orders)
            {
                Console.WriteLine(o.OrderId + " " + o.CustomerId + " " + o.LocationId + " " + o.OrderTime + " " + o.OrderTotal);
                var lines = o.OrderLines;
                foreach (var ol in lines)
                {
                    Console.WriteLine("    " + ol.Quantity + " : " + ol.Product.Name + " " + ol.Product.BestBy + " " + ol.Product.UnitPrice);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("   Press Enter to continue");
            Console.ReadLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Get new order information from user and add to system.
        /// </summary>
        public static void AddOrder(IProject0Repository repository)
        {

            List<Products.IProduct> products = new List<Products.IProduct>(repository.GetProducts());

            // Get CustomerId
            int customerId = -1;
            do
            {
                Console.Write("    Enter CustomerId: ");
                try
                {
                    customerId = int.Parse(Console.ReadLine());
                }
                catch
                {
                    customerId = -1;
                }
            } while (customerId < 0);

            // Get LocationId
            int locationId = -1;
            do
            {
                Console.Write("    Enter LocationId: ");
                try
                {
                    locationId = int.Parse(Console.ReadLine());
                }
                catch
                {
                    locationId = -1;
                }
            } while (locationId < 0);

            // Get OrderTime
            DateTime orderTime = DateTime.Now;
            
            // Get OrderLines
            List<Orders.OrderLine> orderLines = new List<Orders.OrderLine>();
            int count = 0;
            bool done = false;
            do
            {
                // Get OrderLine ProductId
                int productId = -1;
                do
                {
                    Console.Write("    Enter ProductId: ");
                    try
                    {
                        productId = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        productId = -1;
                    }
                } while (productId < 0);

                // Get OrderLine Quantity
                int quantity = -1;
                do
                {
                    Console.Write("    Enter Quantity: ");
                    try
                    {
                        quantity = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        quantity = -1;
                    }
                } while (quantity < 1);

                orderLines.Add(new Orders.OrderLine
                {
                    Product = products[productId],
                    Quantity = quantity
                });
                count++;

                
                Console.Write("    Enter another OrderLine? (Y/N) : ");
                string check = Console.ReadLine().ToLower();
                if (check == "y" || check == "yes")
                {
                    done = false;
                }
                else
                {
                    done = true;
                }
            } while (count < 1 || done == false);



            IOrder order = new Project0.Orders.Order
            {
                CustomerId = customerId,
                LocationId = locationId,
                OrderTime = orderTime,
                OrderLines = orderLines
            };
            repository.AddOrder(order);

            Console.WriteLine();
        }
    }
}
