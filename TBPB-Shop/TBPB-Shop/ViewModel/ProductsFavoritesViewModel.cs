using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class ProductsFavoritesViewModel
    {
        public IEnumerable<ProductFavorites> Products { get; set; }

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
