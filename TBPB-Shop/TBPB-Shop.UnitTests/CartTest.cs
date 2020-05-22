using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void CreateCart_Return_NewProduct()
        {
            //Arrange
            int noOfItems = 0;
            decimal totalPrice = 0;

            //Act
            var cart = Cart.Create();

            //Assert
            Assert.AreEqual(noOfItems, cart.NoOfItems);
            Assert.AreEqual(totalPrice, cart.TotalPrice);
        }
    }
}
