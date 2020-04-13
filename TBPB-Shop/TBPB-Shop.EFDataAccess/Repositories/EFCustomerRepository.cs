using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFCustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public EFCustomerRepository(ShopDbContext dbContext) : base(dbContext)
        { }
        public Customer GetCustomerByUserId(Guid userId)
        {
            var customer = dbContext.Customers.Where(c => c.UserId == userId).SingleOrDefault();
            return customer;
        }
    }
}
