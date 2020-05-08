using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class ProducerDetailsViewModel
    {
        public string ProducerName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
