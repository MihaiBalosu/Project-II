using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Favorites : DataEntity
    {
        public Customer Customer { get; private set; }
        public Guid CustomerId { get; private set; }
        private Favorites()
        {
        }

        public static Favorites Create(Guid customerId)
        {
            return new Favorites
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId
            };
        }
    }
}
