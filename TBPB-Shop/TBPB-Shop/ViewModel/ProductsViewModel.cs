using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Producer> Producers { get; set; }
    }
}
