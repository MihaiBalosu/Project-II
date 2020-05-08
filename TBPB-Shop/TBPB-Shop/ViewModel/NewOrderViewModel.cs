using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ViewModel
{
    public class NewOrderViewModel
    {
        public decimal TotalProductsPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string TypeDelivery { get; set; }
        public string NameDelivery { get; set; }
        public string AddressDelivery { get; set; }
        public string CityDelivery { get; set; }
        public string DistrictDelivery { get; set; }
        public string PhoneDelivery { get; set; }
        public string TypeBilling { get; set; }
        public string NameBilling { get; set; }
        public string AddressBilling { get; set; }
        public string CityBilling { get; set; }
        public string DistrictBilling { get; set; }
        public string PhoneBilling { get; set; }
        public string TypePayment { get; set; }

        public decimal GetNaturalPart(decimal number)
        {
            return Math.Truncate(number);
        }

        public decimal GetCommaPart(decimal number)
        {
            var naturalPart = GetNaturalPart(number);
            return Math.Truncate((number - naturalPart) * 100);
        }
    }
}