using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IFavoritesRepository : IRepository<Favorites>
    {
        Favorites GetByCustomerId(Guid customerId);
        IEnumerable<ProductFavorites> GetProductsForCustomer(Guid favoritesId);
        ProductFavorites AddProductToFavorites(ProductFavorites product);
        void RemoveProductFromFavorites(Guid id, Guid guidProductId);
        ProductFavorites GetProduct(Guid favoritesId, Guid productId);
    }
}
