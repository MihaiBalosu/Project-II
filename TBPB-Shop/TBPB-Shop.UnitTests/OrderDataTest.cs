using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.UnitTests
{
    [TestClass]
    public class OrderDataTest
    {
        [TestMethod]
        public void CreateOrder_Return_NewOrder()
        {
            //Arrange
            Guid customerId = Guid.NewGuid();
            decimal totalProductsPrice = 100;
            decimal priceDelivery = 25;
            decimal totalPrice = 125;
            string typeDelivery = "TBPB";
            string nameDelivery = "Car";
            string phoneDelivery = "0722";
            string cityDelivery = "Craiova";
            string districtDelivery = "Dolj";
            string addressDelivery = "Home";
            string typeBilling = "Card";
            string nameBilling = "ING";
            string phoneBilling = "0351";
            string cityBilling = "Bucharest";
            string districtBilling = "Bucharest";
            string addressBilling = "Company";
            string typePayment = "Cash";

            //Act
            var order = OrderData.Create( customerId,
                                        totalProductsPrice,
                                        priceDelivery,
                                        totalPrice,
                                        typeDelivery,
                                        nameDelivery,
                                        phoneDelivery,
                                        cityDelivery,
                                        districtDelivery,
                                        addressDelivery,
                                        typeBilling,
                                        nameBilling,
                                        phoneBilling,
                                        cityBilling,
                                        districtBilling,
                                        addressBilling,
                                        typePayment);

            //Assert
            Assert.AreEqual(customerId, order.CustomerId);
            Assert.AreEqual(totalProductsPrice, order.TotalProductsPrice);
            Assert.AreEqual(priceDelivery, order.PriceDelivery);
            Assert.AreEqual(totalPrice, order.TotalPrice);
            Assert.AreEqual(typeDelivery, order.TypeDelivery);
            Assert.AreEqual(nameDelivery, order.NameDelivery);
            Assert.AreEqual(phoneDelivery, order.PhoneDelivery);
            Assert.AreEqual(cityDelivery, order.CityDelivery);
            Assert.AreEqual(districtDelivery, order.DistrictDelivery);
            Assert.AreEqual(addressDelivery, order.AddressDelivery);
            Assert.AreEqual(typeBilling, order.TypeBilling);
            Assert.AreEqual(nameBilling, order.NameBilling);
            Assert.AreEqual(phoneBilling, order.PhoneBilling);
            Assert.AreEqual(cityBilling, order.CityBilling);
            Assert.AreEqual(districtBilling, order.DistrictBilling);
            Assert.AreEqual(addressBilling, order.AddressBilling);
            Assert.AreEqual(typePayment, order.TypePayment);
        }
    }
}
