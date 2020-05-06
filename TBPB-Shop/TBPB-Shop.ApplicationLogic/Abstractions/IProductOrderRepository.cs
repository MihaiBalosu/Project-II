using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IProductOrderRepository : IRepository<ProductOrder>
    {
        IEnumerable<ProductOrder> AddProductsList(IEnumerable<ProductOrder> productsList);
        IEnumerable<ProductOrder> GetProductsFromOrder(Guid orderId);
    }
}
