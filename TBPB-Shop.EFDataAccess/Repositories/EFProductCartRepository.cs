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

        public ProductCart UpdateProductQuantity(Guid productCartId, int quantity)
        {
            var foundProductCart = dbContext.ProductCart.Where(productCart => productCart.Id == productCartId).SingleOrDefault();
            foundProductCart.UpdateQuantity(quantity);
            return Update(foundProductCart);
            
        }
    }
}
