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

        public void Clear(Guid cartId)
        {
            var cart = GetById(cartId);
            cart.Reset();
            Update(cart);
        }

        public Cart GetCartFromUserId(Guid userId)
        {
            var foundCart = dbContext.Carts.Where(cart => cart.Id == userId).SingleOrDefault();
            return foundCart;
        }
    }
}
