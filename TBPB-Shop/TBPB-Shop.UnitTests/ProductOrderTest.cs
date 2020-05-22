using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class ProductOrderTest
    {
        [TestMethod]
        public void CreateProductOrder_Return_NewProductOrder()
        {
            //Arrange
            Guid prodId = Guid.NewGuid();
            Guid orderId = Guid.NewGuid();
            int quantity = 5;

            //Act
            var prodOrd = ProductOrder.Create(prodId, orderId, quantity);

            //Assert
            Assert.AreEqual(orderId, prodOrd.OrderId);
            Assert.AreEqual(prodId, prodOrd.ProductId);
            Assert.AreEqual(quantity, prodOrd.Quantity);
        }
    }
}
