using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPBShop.Models.ShopModels
{
    public class Producer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
