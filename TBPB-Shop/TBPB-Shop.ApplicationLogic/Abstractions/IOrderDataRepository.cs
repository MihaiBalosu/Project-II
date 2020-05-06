using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IOrderDataRepository : IRepository<OrderData>
    {
        IEnumerable<OrderData> GetAllWithCustomerId(Guid id);
    }
}
