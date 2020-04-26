using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFCategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public EFCategoryRepository(ShopDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Product> getProductsForCategory(Guid id)
        {
            return dbContext.Products.Where(entity => entity.CategoryId.Equals(id));

        }
    }
}
