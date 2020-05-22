using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;
using TBPB_Shop.ApplicationLogic.Services;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class ProductServiceTest
    {
        public Mock<IProductRepository> prodRepoMock = new Mock<IProductRepository>();

        [TestMethod]
        public void AddProduct_Returns_AddedProduct()
        {
            var name = "Pere";
            var price = 2;
            var quantity = 3;
            var categoryId = Guid.NewGuid();
            var producerId = Guid.NewGuid();
            var prod = Product.Create(name, price, quantity, categoryId, producerId);

            prodRepoMock.Setup(prodRepo => prodRepo.Create(name, price, quantity, categoryId, producerId))
                        .Returns(prod);
            var productService = new ProductService(prodRepoMock.Object);

            var productAdded = productService.Add(name, price, quantity, categoryId, producerId);

            Assert.IsNotNull(productAdded);
            Assert.AreEqual(name, productAdded.Name);
            Assert.AreEqual(price, productAdded.Price);
            Assert.AreEqual(quantity, productAdded.QuantityOnStoc);
            Assert.AreEqual(categoryId, productAdded.CategoryId);
            Assert.AreEqual(producerId, productAdded.ProducerId);
        }

        [TestMethod]
        public void UpdateProduct_Returns_UpdatedProduct()
        {
            var prod = Product.Create("asd", 2, 3, Guid.NewGuid(), Guid.NewGuid());
            var name = "Pere";
            var price = 2;
            var quantity = 3;
            var categoryId = Guid.NewGuid();
            var producerId = Guid.NewGuid();
            var prodUpdated = prod.CreateUpdate(name, price, quantity, categoryId);

            prodRepoMock.Setup(prodRepo => prodRepo.Update(prodUpdated))
                        .Returns(prodUpdated);

            prodRepoMock.Setup(prodRepo => prodRepo.GetById(prod.Id))
                        .Returns(prod);

            var productService = new ProductService(prodRepoMock.Object);

            var productAdded = productService.Update(prod.Id.ToString(), name, price, quantity, categoryId);

            Assert.IsNotNull(productAdded);
            Assert.AreEqual(prodUpdated.Name, productAdded.Name);
            Assert.AreEqual(prodUpdated.Price, productAdded.Price);
            Assert.AreEqual(prodUpdated.QuantityOnStoc, productAdded.QuantityOnStoc);
            Assert.AreEqual(prodUpdated.CategoryId, productAdded.CategoryId);
        }
    }
}
