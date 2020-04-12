using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Exceptions
{
    public class CartNotFoundException : Exception
    {
        public string Id { get; private set; }

        public CartNotFoundException(string Id) : base($"Cart with Id : {Id} was not found")
        {
            this.Id = Id;
        }
    }
}
