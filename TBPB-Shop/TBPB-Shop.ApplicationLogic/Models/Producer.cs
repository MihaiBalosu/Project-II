using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Producer : DataEntity
    {
        public string Name { get; private set; }
        //public virtual ICollection<Product> Products { get; private set; }

        private Producer()
        { }

        public static Producer Create(string name)
        {
            Producer producer = new Producer
            {
                Id = Guid.NewGuid(),
                Name = name,
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

        
    }
}
