using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFCartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly IProductCartRepository productCartRepository;

        public EFCartRepository(ShopDbContext dbContext, IProductCartRepository productCartRepository) : base(dbContext)
        {
            this.productCartRepository = productCartRepository;
        }

        public Cart GetCartFromUserId(Guid userId)
        {
            var foundCart = dbContext.Carts.Where(cart => cart.Id == userId).SingleOrDefault();
            return foundCart;
        }

        public IEnumerable<ProductCart> GetAllProducts(Guid cartId)
        {
            var productsCartList = dbContext.ProductCart.Where(productCart => productCart.CartId == cartId);
            return productsCartList;
        }

        public ProductCart AddProduct(Guid cartId, Product product, int quantity)
        {
            var productCart = ProductCart.Create(cartId, product, quantity);
            productCartRepository.Add(productCart);
            return productCart;
        }

        public ProductCart DeleteProduct(Guid cartId, Guid productId)
        {
            var productCartList = GetAllProducts(cartId);
            var foundProductCart = productCartList?.Where(productCart => productCart.ProductId == productId).SingleOrDefault();
            productCartRepository.Remove(foundProductCart.Id);
            return foundProductCart;
        }

        public ProductCart UpdateProductQuantity(Guid cartId, Guid productId, int quantity)
        {
            var productCartList = GetAllProducts(cartId);
            var foundProductCart = productCartList?.Where(productCart => productCart.ProductId == productId).SingleOrDefault();
            return productCartRepository.UpdateProductQuantity(foundProductCart.Id, quantity);
        }
    }
}
