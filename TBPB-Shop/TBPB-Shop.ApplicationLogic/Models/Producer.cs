using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Producer : DataEntity
    {
        public string Name { get; private set; }
        public List<Product> Products { get; private set; }

        private Producer()
        { }

        public static Producer Create(string name)
        {
            Producer producer = new Producer
            {
                Id = Guid.NewGuid(),
                Name = name,
                Products = new List<Product>()
            };
            return producer;
        }
        public static Producer CreateUpdate(Guid id, string name)
        {
            Producer producer = new Producer
            {
                Id = id,
                Name = name
            };
            return producer;
        }

        public void AddProductToList(Product prodObj)
        {
            Console.WriteLine(this);
            this.Products.Add(prodObj);
        }
    }
}
