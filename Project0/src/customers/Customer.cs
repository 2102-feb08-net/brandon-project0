

using System.Collections.Generic;
using Project0.Orders;

namespace Project0.Customers
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Address { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string PostalCode { get; private set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }


        public Customer(int customerId, string firstName, string lastName, string address, string city, string state, string country, string postalCode, string phone, string email)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Email = email;
        }



        public List<IOrder> GetOrderHistory()
        {
            throw new System.NotImplementedException();
        }

        public void SetFullAddress(string address, string city, string country, string state = "", string postalcode = "")
        {
            throw new System.NotImplementedException();
        }
    }
}