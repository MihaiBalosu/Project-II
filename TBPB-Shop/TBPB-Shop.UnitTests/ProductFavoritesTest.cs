using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class ProductFavoritesTest
    {
        [TestMethod]
        public void CreateProductFavorite_Return_NewProductFavorite()
        {
            //Arrange
            Guid favId = Guid.NewGuid();
            Guid prodId = Guid.NewGuid();

            //Act
            var prodFav = ProductFavorites.Create(favId, prodId);

            //Assert
            Assert.AreEqual(favId, prodFav.FavoritesId);
            Assert.AreEqual(prodId, prodFav.ProductId);
        }
    }
}
