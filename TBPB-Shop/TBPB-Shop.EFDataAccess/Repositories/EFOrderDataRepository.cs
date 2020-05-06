using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFOrderDataRepository : BaseRepository<OrderData>, IOrderDataRepository
    {
        public EFOrderDataRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<OrderData> GetAllWithCustomerId(Guid customerId)
        {
            return dbContext.Orders
                            .Where(order => order.CustomerId == customerId);
        }
    }
}
