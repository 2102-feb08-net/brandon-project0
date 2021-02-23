using System;
using Xunit;
using Project0.Customers;

namespace Project0.Tests.Logic
{
    public class Customer_Tests
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData(null, null)]
        public void Constructor_NullFirstOrLast_ThrowException(string first, string last)
        {
            // arrange
            Customer customer;

            // act
            bool exceptionThrown = false;
            try 
            {
                customer = new Customer(first, last, "", "", "", "", "", "", "", 1);
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
