using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IProductCartRepository : IRepository<ProductCart>
    {
        ProductCart UpdateProductQuantity(Guid Id, int quantity);
    }
}
