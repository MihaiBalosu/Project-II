using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Create(string name, decimal price, int quantityOnStoc, Guid categoryId, Guid producerId);
        IEnumerable<Product> getProductsForCategory(string name);
    }
}
