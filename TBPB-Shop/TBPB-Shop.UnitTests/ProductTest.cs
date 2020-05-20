using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void CreateProduct_Return_NewProduct()
        {
            //Arrange
            string name = "Product";
            decimal price = 1;
            int quantityOnStock = 10;
            Guid categoryId = Guid.NewGuid();
            Guid producerId = Guid.NewGuid();

            //Act
            var product = Product.Create(name, price, quantityOnStock, categoryId, producerId);

            //Assert
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantityOnStock, product.QuantityOnStoc);
            Assert.AreEqual(categoryId, product.CategoryId);
            Assert.AreEqual(producerId, product.ProducerId);
        }

        [TestMethod]
        public void CreateUpdateProduct_Return_UpdateProduct()
        {
            Product prodObj = Product.Create("Pope", 20, 20, Guid.NewGuid(), Guid.NewGuid());
            var OldName = prodObj.Name;
            var OldPrice = prodObj.Price;
            var oldQuantity = prodObj.QuantityOnStoc;
            var oldCategoryId = prodObj.CategoryId;

            //Arrange
            string name = "Product";
            decimal price = 1;
            int quantityOnStock = 10;
            Guid categoryId = Guid.NewGuid();

            //Act
            prodObj.CreateUpdate(name, price, quantityOnStock, categoryId);

            //Assert
            Assert.AreNotEqual(prodObj.Name, OldName);
            Assert.AreNotEqual(prodObj.Price, OldPrice);
            Assert.AreNotEqual(prodObj.QuantityOnStoc, oldQuantity);
            Assert.AreNotEqual(prodObj.CategoryId, oldCategoryId);
        }
    }
}
