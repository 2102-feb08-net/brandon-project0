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
                order = new Order
                {
                    CustomerId = customerId,
                    LocationId = 1,
                    OrderTime = new DateTime(),
                    OrderTotal = 1.00M,
                    OrderLines = new List<OrderLine>()
                };
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
                order = new Order
                {
                    CustomerId = 1,
                    LocationId = locationId,
                    OrderTime = new DateTime(),
                    OrderTotal = 1.00M,
                    OrderLines = new List<OrderLine>()
                };
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
