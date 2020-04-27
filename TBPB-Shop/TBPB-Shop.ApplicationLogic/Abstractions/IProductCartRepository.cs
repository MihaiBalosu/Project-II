using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IProductCartRepository : IRepository<ProductCart>
    {
        IEnumerable<ProductCart> GetAllProductsFromCart(Guid cartId);
        ProductCart AddProductToCart(Cart cart, Product product, int quantity);
        void DeleteProductFromCart(Guid cartId, Guid productId);
        void ClearCart(Guid cartId);
        Boolean IsProductAddedToCart(Guid cartId, Guid productId);
        ProductCart GetByProductIdCartId(Guid cartId, Guid productId);
        //ProductCart UpdateProductQuantity(Guid cartId, int quantity);
    }
}
