using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFProductCartRepository : BaseRepository<ProductCart>, IProductCartRepository
    {
        public EFProductCartRepository(ShopDbContext dbContext) : base(dbContext)
        {}
        
        public ProductCart AddProductToCart(Cart cart, Product product, int quantity)
        {
            if (IsProductAddedToCart(cart.Id, product.Id) == false)
            {
                var productCart = ProductCart.Create(cart, product, quantity);
                return Add(productCart);
            }

            var foundProductCart = GetByProductIdCartId(cart.Id, product.Id);
            foundProductCart.UpdateQuantity(1);
            Update(foundProductCart);
            return foundProductCart;
        }

        public void ClearCart(Guid cartId)
        {
            var productsCartList = GetAllProductsFromCart(cartId);
            dbContext.ProductCart.RemoveRange(productsCartList);
            dbContext.SaveChanges();
        }

        public void DeleteProductFromCart(Guid cartId, Guid productId)
        {
            var productCartList = GetAllProductsFromCart(cartId);
            var foundProductCart = productCartList?.Where(productCart => productCart.ProductId == productId)
                                                   .SingleOrDefault();
            Remove(foundProductCart.Id);
        }

        public IEnumerable<ProductCart> GetAllProductsFromCart(Guid cartId)
        {
            var productsCartList = dbContext.ProductCart
                                            .Where(productCart => productCart.CartId == cartId);

            foreach (var productCart in productsCartList)
            {
                var product = dbContext.Products
                                        .Where(p => p.Id == productCart.ProductId)
                                        .SingleOrDefault();
                productCart.Update(product);
            }

            return productsCartList;
        }

        public ProductCart GetByProductIdCartId(Guid cartId, Guid productId)
        {
            return dbContext.ProductCart
                            .Where(productCart => ((productCart.CartId == cartId) && 
                                                   (productCart.ProductId == productId)))
                            .SingleOrDefault();
        }

        public bool IsProductAddedToCart(Guid cartId, Guid productId)
        {
            var productCartList = GetAllProductsFromCart(cartId);
            var searchedProduct = productCartList.Where(product => product.ProductId == productId)
                                                 .SingleOrDefault();

            if (searchedProduct != null)
            {
                return true;
            }

            return false;
        }

    }
}
