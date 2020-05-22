using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class FavoritesTest
    {
        [TestMethod]
        public void CreateFavorite_Return_NewProduct()
        {
            //Arrange
            Guid customerId = Guid.NewGuid();

            //Act
            var fav = Favorites.Create(customerId);

            //Assert
            Assert.AreEqual(customerId, fav.CustomerId);
        }
    }
}
