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

        [TestMethod]
        public void UpdateNoOfItems_Updates_NoOfItemsPlusOne()
        {
            //Arrange
            var cart = Cart.Create();
            var noOfItems = cart.NoOfItems;

            //Act
            cart.UpdateNoOfItems();

            //Assert
            Assert.AreEqual(cart.NoOfItems, noOfItems + 1);
        }

        [TestMethod]
        public void UpdateTotalPrice_Updates_CartTotalPriceWithProductQuantityMultipliedWithProductPrice()
        {
            //Arrange
            var cart = Cart.Create();
            var quantity = 10;
            var price = 20;

            //Act
            var newPrice = cart.TotalPrice + price * quantity;
            cart.UpdateTotalPrice(price, quantity);

            //Assert
            Assert.AreEqual(cart.TotalPrice, newPrice);
        }

        [TestMethod]
        public void Reset_Resets_NoOfItemsAndTotalPriceForCart()
        {
            var cart = Cart.Create();

            //Act
            cart.Reset();

            //Assert
            Assert.AreEqual(cart.TotalPrice, 0);
            Assert.AreEqual(cart.NoOfItems, 0);
        }
    }
}
