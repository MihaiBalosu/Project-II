using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCartFromUserId(Guid userId);
        IEnumerable<ProductCart> GetAllProducts(Guid cartId);
        ProductCart AddProduct(Guid cartId, Product product, int quantity);
        ProductCart DeleteProduct(Guid cartId, Guid productId);
        ProductCart UpdateProductQuantity(Guid cartId, Guid productId, int quantity);
    }
}
