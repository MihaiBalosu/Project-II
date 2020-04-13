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
        protected new readonly ShopDbContext dbContext;

        public ProductRepository(ShopDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> getProductsForCategory(string name)
        {
            return dbContext.Set<Product>()
                .Where(entity => entity.Name.Equals(name));
        }

        public Product Create(string name, decimal price, int quantityOnStoc)
        {
            Product prod = Product.Create(name, price, quantityOnStoc);
            return Add(prod);
        }
    }
}
