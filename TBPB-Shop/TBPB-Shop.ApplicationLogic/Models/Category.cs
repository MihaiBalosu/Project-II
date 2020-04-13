using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Category : DataEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }
    }
}
