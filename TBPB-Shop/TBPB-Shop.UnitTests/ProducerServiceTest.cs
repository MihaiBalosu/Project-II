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
    public class ProducerServiceTest
    {
        private Mock<IProducerRepository> producerRepoMock = new Mock<IProducerRepository>();
        private Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();

        [TestMethod]
        public void addProducer_Returns_AddedProducer()
        {
            var name = "Philips";

            var prod = Producer.Create(name);

            producerRepoMock.Setup(producerRepo => producerRepo.Create(name)).Returns(prod);

            var producerService = new ProducerService(producerRepoMock.Object, productRepoMock.Object);

            var producerAdded = producerService.Add(name);

            Assert.IsNotNull(producerAdded);
            Assert.AreEqual(name, producerAdded.Name);
        }

        [TestMethod]
        public void updateProducer_Returns_updatedProducer()
        {
            var prod = Producer.Create("Philips");
            var name = "Sony";

            var prodUpdated = prod.CreateUpdate(name);

            producerRepoMock.Setup(producerRepo => producerRepo.Update(prodUpdated)).Returns(prodUpdated);

            producerRepoMock.Setup(producerRepo => producerRepo.GetById(prod.Id)).Returns(prod);

            var producerService = new ProducerService(producerRepoMock.Object, productRepoMock.Object);

            var producerAdded = producerService.Update(prod.Id, name);

            Assert.IsNotNull(producerAdded);
            Assert.AreEqual(prodUpdated.Name, producerAdded.Name);
        }
    }
}
