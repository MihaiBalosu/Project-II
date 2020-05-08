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

        public Product Create(string name, decimal price, int quantityOnStoc, Guid categoryId, Guid producerId)
        {
            Product prod = Product.Create(name, price, quantityOnStoc, categoryId, producerId);
            return Add(prod);
        }

        public IEnumerable<Product> UpdateProducts(IEnumerable<Product> productsList)
        {
            dbContext.Products.UpdateRange(productsList);
            dbContext.SaveChanges();
            return productsList;
        }

        public void RemoveList(IEnumerable<Product> productsList)
        {
            dbContext.Products.RemoveRange(productsList);
            dbContext.SaveChanges();
        }
    }
}
