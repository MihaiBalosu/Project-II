using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Producer
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public List<Product> Products { get; private set; }

        private Producer()
        { }

        public static Producer Create(Guid id, string name)
        {
            Producer producer = new Producer
            {
                ID = id,
                Name = name,
                Products = new List<Product>()
            };

            return producer;
        }
    }
}
