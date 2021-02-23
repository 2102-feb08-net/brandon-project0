
using System;
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


        public Customer(string firstName, string lastName, string address, string city, string state, string country, string postalCode, string phone, string email, int customerId = 0)
        {
            CustomerId = customerId;
            FirstName = firstName ?? throw new ArgumentException($"Customer FirstName must not be null");
            LastName = lastName ?? throw new ArgumentException($"Customer LastName must not be null");
            Address = address;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Email = email ?? throw new ArgumentException($"Customer LastName must not be null");
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