using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPBShop.Models.ShopModels
{
    public class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
