using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByUserId(Guid userId);
    }
}
