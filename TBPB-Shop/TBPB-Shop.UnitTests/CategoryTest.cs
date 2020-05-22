using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CreateCategory_Return_NewCategory()
        {
            string categoryName = "Monitors";
            string categoryDescription = "Output device";

            var category = Category.Create(categoryName, categoryDescription);

            Assert.AreEqual(categoryName, category.Name);
            Assert.AreEqual(categoryDescription, category.Description);
        }

        [TestMethod]
        public void CreateUpdate_Return_UpdatedCategory()
        {
            Category categoryObject = Category.Create("Mobilier", "Scaun");
            var initialCategoryName = categoryObject.Name;
            var initialCategoryDescription = categoryObject.Description;

            string newCategoryName = "Ustensile";
            string newCategoryDescriptio = "Cutit";

            categoryObject.CreateForUpdate(newCategoryName, newCategoryDescriptio);

            Assert.AreNotEqual(categoryObject.Name, initialCategoryName);
            Assert.AreNotEqual(categoryObject.Description, initialCategoryDescription);
        }

    }
}
