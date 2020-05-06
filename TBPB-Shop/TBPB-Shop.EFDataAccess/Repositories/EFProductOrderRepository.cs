using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFProductOrderRepository : BaseRepository<ProductOrder>, IProductOrderRepository
    {
        public EFProductOrderRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ProductOrder> AddProductsList(IEnumerable<ProductOrder> productsList)
        {
            dbContext.AddRange(productsList);
            dbContext.SaveChanges();
            return productsList;
        }
    }
}
