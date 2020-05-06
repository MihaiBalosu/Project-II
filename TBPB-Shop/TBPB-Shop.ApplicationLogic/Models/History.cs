using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class History : DataEntity
    {
        public Customer Customer { get; private set; }
        public OrderData Order { get; private set; }
    }
}
