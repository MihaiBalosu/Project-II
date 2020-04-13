using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class ProductsCreateUpdateViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnStoc { get; set; }
        public Guid ProducerId { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Producer> Producers { get; set; }
    }
}
