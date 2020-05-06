using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class ProductOrder : DataEntity
    {
        public ProductCart Product { get; private set; }
        public Guid ProductId { get; private set; }
        public OrderData Order { get; private set; }
        public Guid OrderId { get; private set; }

        public static ProductOrder Create(Guid productId, Guid orderId)
        {
            return new ProductOrder
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                OrderId = orderId
            };
        }
    }
}
