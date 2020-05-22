using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class ProducerTest
    {
        [TestMethod]
        public void CreateProducer_Return_NewProduct()
        {
            //Arrange
            string name = "Producer";

            //Act
            var product = Producer.Create(name);

            //Assert
            Assert.AreEqual(name, product.Name);
        }

        [TestMethod]
        public void CreateUpdateProduct_Return_UpdateProduct()
        {
            Producer prodObj = Producer.Create("Philips");
            var OldName = prodObj.Name;

            //Arrange
            string name = "Sony";

            //Act
            prodObj.CreateUpdate(name);

            //Assert
            Assert.AreNotEqual(prodObj.Name, OldName);
            
        }
    }
}
