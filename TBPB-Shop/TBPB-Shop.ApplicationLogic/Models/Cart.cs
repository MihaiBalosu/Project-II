using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Cart: DataEntity
    {
        public int NoOfItems { get; private set; }
        public decimal TotalPrice { get; private set; }

        private Cart()
        { }

        public static Cart Create()
        {
            return new Cart
            {
                Id = Guid.NewGuid(),
                NoOfItems = 0,
                TotalPrice = 0
            };
        }

        public int UpdateNoOfItems()
        {
            this.NoOfItems++;
            return this.NoOfItems;
        }

        public decimal UpdateTotalPrice(decimal productPrice, int productQuantity)
        {
            this.TotalPrice += (productPrice * productQuantity);
            return this.TotalPrice;
        }

        public void Reset()
        {
            this.NoOfItems = 0;
            this.TotalPrice = 0;
        }
    }
}
