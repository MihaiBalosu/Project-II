using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class ProductOrder : DataEntity
    {
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public OrderData Order { get; private set; }
        public Guid OrderId { get; private set; }

        public static ProductOrder Create(Guid productId, Guid orderId, int quantity)
        {
            return new ProductOrder
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                OrderId = orderId,
                Quantity = quantity
            };
        }

        public ProductOrder Update(Product product)
        {
            this.Product = product;
            return this;
        }
    }
}
