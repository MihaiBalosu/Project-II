using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void CreateCustomer_Return_NewProduct()
        {
            //Arrange
            Guid userId = Guid.NewGuid();
            string firstName = "Ion";
            string lastName = "Ionescu";
            Guid cartId = Guid.NewGuid();

            //Act
            var customer = Customer.Create(userId, firstName, lastName, cartId);

            //Assert
            Assert.AreEqual(userId, customer.UserId);
            Assert.AreEqual(firstName, customer.FirstName);
            Assert.AreEqual(lastName, customer.SecondName);
            Assert.AreEqual(cartId, customer.CartId);
        }
    }
}
