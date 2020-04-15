using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public IEnumerable<ProductCart> Products { get; set; }
        public int NoOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
