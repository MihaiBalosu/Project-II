using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Exceptions
{
    public class ProductException : Exception
    {
        public Guid productId { get; private set; }

        public ProductException(Guid productID) : base($"Product with id {productID} was not found!")
        {
            productId = productID;
        }
    }
}
