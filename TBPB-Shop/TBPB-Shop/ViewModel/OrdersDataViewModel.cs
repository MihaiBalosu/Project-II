using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ViewModel
{
    public class OrdersDataViewModel
    {
        public IEnumerable<OrderData> Orders { get; set; }
    }
}
