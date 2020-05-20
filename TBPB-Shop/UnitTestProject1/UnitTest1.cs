using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBPB_Shop.ApplicationLogic.Models;

namespace UnitTests1
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

            Assert.AreEqual(categoryObject.Name, newCategoryName);
            Assert.AreEqual(categoryObject.Description, newCategoryDescriptio);
        }

    }
}
