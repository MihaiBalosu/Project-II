using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }

        public Product Create(string name, decimal price, int quantityOnStoc, Guid producerId)
        {
            Product prod = Product.Create(name, price, quantityOnStoc);
            
            return Add(prod);
        }
    }
}
