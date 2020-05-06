﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class OrderData : DataEntity
    {
        public Guid CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime DatePlacedOn { get; private set; }
        public string TypeDelivery { get; private set; }
        public string NameDelivery { get; private set; }
        public string AddressDelivery { get; private set; }
        public string CityDelivery { get; private set; }
        public string DistrictDelivery { get; private set; }
        public string PhoneDelivery { get; private set; }
        public string TypeBilling { get; private set; }
        public string NameBilling { get; private set; }
        public string AddressBilling { get; private set; }
        public string CityBilling { get; private set; }
        public string DistrictBilling { get; private set; }
        public string PhoneBilling { get; private set; }
        public string TypePayment { get; private set; }
        public string NameCardPayment { get; private set; }
        public string AmountCardPayment { get; private set; }
        public string CVVCardPayment { get; private set; }
        public string NumberCardPayment { get; private set; }
        public DateTime ExpireDateCardPayment { get; private set; }

        private OrderData()
        { 
        }

        public static OrderData Create(Guid customerId,
                                       decimal totalPrice,
                                       string typeDelivery,
                                       string nameDelivery,
                                       string phoneDelivery,
                                       string cityDelivery,
                                       string districtDelivery,
                                       string addressDelivery,
                                       string typeBilling,
                                       string nameBilling,
                                       string phoneBilling,
                                       string cityBilling,
                                       string districtBilling,
                                       string addressBilling,
                                       string typePayment,
                                       string nameCardPayment,
                                       string amountCardPayemnt,
                                       string cvvCardPayment,
                                       string numberCardPayemnt,
                                       DateTime expireDateCardPayment)
        {
            return new OrderData
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                TotalPrice = totalPrice,
                DatePlacedOn = DateTime.Today,
                TypeDelivery = typeDelivery,
                NameDelivery = nameDelivery,
                PhoneDelivery = phoneDelivery,
                DistrictDelivery = districtDelivery,
                AddressDelivery = addressDelivery,
                TypeBilling = typeBilling,
                NameBilling = nameBilling,
                PhoneBilling = phoneBilling,
                CityBilling = cityBilling,
                DistrictBilling = districtBilling,
                AddressBilling = addressBilling,
                TypePayment = typePayment,
                NameCardPayment = nameCardPayment,
                AmountCardPayment = amountCardPayemnt,
                CVVCardPayment = cvvCardPayment,
                NumberCardPayment = numberCardPayemnt,
                ExpireDateCardPayment = expireDateCardPayment
            };
        }

        public int GetNumberOrder()
        {
            Random random = new Random();
            return random.Next(100000000, 1000000000);
        }
    }
}
