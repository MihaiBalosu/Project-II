using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class ProductCart : DataEntity
    {
        public Cart Cart { get; private set; }
        public Guid CartId { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }


        private ProductCart()
        { }

        public static ProductCart Create(Cart cart, Product product, int quantity)
        {
            return new ProductCart
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                ProductId = product.Id,
                Product = product,
                Cart = cart,
                Quantity = quantity,
            };
        }

        public int UpdateQuantity(int quantity)
        {
            this.Quantity += quantity;
            return this.Quantity;
        }

        public ProductCart Update(Product product)
        {
            this.Product = product;
            return this;
        }
    }
}
