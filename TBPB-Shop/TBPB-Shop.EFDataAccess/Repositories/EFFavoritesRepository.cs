using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFFavoritesRepository : BaseRepository<Favorites>, IFavoritesRepository
    {
        public EFFavoritesRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }

        public Favorites GetByCustomerId(Guid customerId)
        {
            return dbContext.Favorites
                            .Where(favorites => favorites.CustomerId == customerId)
                            .SingleOrDefault();
        }

        public IEnumerable<ProductFavorites> GetProductsForCustomer(Guid favoritesId)
        {
            var productFavoritesList =  dbContext.ProductFavorites
                                                 .Where(product => product.FavoritesId == favoritesId);
            foreach (var item in productFavoritesList)
            {
                var product = dbContext.Products
                                       .Where(p => p.Id == item.ProductId)
                                       .SingleOrDefault();
                item.Update(product);
            }
            return productFavoritesList;
        }

        public ProductFavorites AddProductToFavorites(ProductFavorites product)
        {
            dbContext.Add<ProductFavorites>(product);
            dbContext.SaveChanges();
            return product;
        }

        public ProductFavorites GetProduct(Guid favoritesId, Guid productId)
        {
            return dbContext.ProductFavorites
                            .Where(product => (product.ProductId == productId) &&
                                              (product.FavoritesId == favoritesId))
                            .SingleOrDefault();
        }
        public void RemoveProductFromFavorites(Guid favoritesId, Guid productId)
        {
            var productToRemove = GetProduct(favoritesId, productId);
            dbContext.Remove<ProductFavorites>(productToRemove);
            dbContext.SaveChanges();
        }
    }
}
