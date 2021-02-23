using System;
using System.Collections.Generic;
using Xunit;


using Project0.Customers;
using Project0.Products;
using Project0.Locations;
using Project0.Orders;

namespace Project0.Tests.Logic
{
    public class Order_Tests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidCustomerId_ThrowException(int customerId)
        {
            // arrange
            Order order;

            // act
            bool exceptionThrown = false;
            try 
            {
                order = new Order(customerId, 1, new DateTime(), new Dictionary<Product, int>());
            }
            catch
            {
                exceptionThrown = true;
            }

            // assert
            Assert.True(exceptionThrown);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidLocationId_ThrowException(int locationId)
        {
            // arrange
            Order order;

            // act
            bool exceptionThrown = false;
            try 
            {
                order = new Order(1, locationId, new DateTime(), new Dictionary<Product, int>());
            }
            catch
            {
                exceptionThrown = true;
            }

            // assert
            Assert.True(exceptionThrown);
        }
    }
}
