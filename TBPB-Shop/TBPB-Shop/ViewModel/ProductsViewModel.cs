using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class ProductsViewModel
    {
        public Guid ProducerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Producer> Producers { get; set; }

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
