using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Product> getProductsForCategory(Guid id);
    }
}
