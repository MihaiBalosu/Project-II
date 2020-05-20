using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;
using TBPB_Shop.ApplicationLogic.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestsServices
    {
        
        private Mock<ICategoryRepository> categoryRepoMock = new Mock<ICategoryRepository>();
        private Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();


        [TestMethod]
        public void addCategory_Returns_AddedCategory()
        {
            var name = "Laptop";
            var description = "Cele mai bune";

            var category = Category.Create(name, description);

            categoryRepoMock.Setup(categoryRepo => categoryRepo.Add(category)).Returns(category);
            categoryRepoMock.Setup(categoryRepo => categoryRepo.Create(name, description)).Returns(category);

            var categoryService = new CategoryService(categoryRepoMock.Object, productRepoMock.Object);

            var categoryAdded = categoryService.Add(name, description);

            Assert.IsNotNull(categoryAdded);
            Assert.AreEqual(name, categoryAdded.Name);
        }

        [TestMethod]
        public void updateCategory_Returns_updatedCategory()
        {
            var category = Category.Create("Frigidere", "Cele mai bune");
            var name = "Lazi frigorifice";
            var description = "Nu cele mai bune";

            var categoryUpdated = category.CreateForUpdate(name, description);

            categoryRepoMock.Setup(categoryRepo => categoryRepo.Update(categoryUpdated)).Returns(categoryUpdated);

            categoryRepoMock.Setup(categoryRepo => categoryRepo.GetById(category.Id)).Returns(category);

            var categoryService = new CategoryService(categoryRepoMock.Object, productRepoMock.Object);

            var categoryAdded = categoryService.Update(category.Id, name, description);

            Assert.IsNotNull(categoryAdded);
            Assert.AreEqual(categoryUpdated.Name, categoryAdded.Name);
        }
    }
}
