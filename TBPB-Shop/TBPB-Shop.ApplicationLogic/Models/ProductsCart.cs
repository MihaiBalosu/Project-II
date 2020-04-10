using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class ProductsCart
    {
        public Guid Id { get; private set; }
        public Cart Cart { get; private set; }
        public Guid CartId { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
    }
}
