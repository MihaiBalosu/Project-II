using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPBShop.Models.ShopModels
{
    public class Cart
    {
        public string ID { get; set; }
        public ShopUser ShopUser { get; set; }
        public string ShopUserID { get; set; }
        public Product Product { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
