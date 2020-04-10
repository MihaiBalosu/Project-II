using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Cart
    {
        public Guid ID { get; private set; }
        public int NoOfItems { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}
