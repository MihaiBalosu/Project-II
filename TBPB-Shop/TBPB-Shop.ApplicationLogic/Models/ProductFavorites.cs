using System;
using System.Collections.Generic;
using System.Text;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class ProductFavorites : DataEntity
    {
        public Favorites Favorites { get; private set; }
        public Guid FavoritesId { get; private set; }
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }

        private ProductFavorites()
        {
        }

        public static ProductFavorites Create(Guid favoritesId, Guid productId)
        {
            return new ProductFavorites
            {
                Id = Guid.NewGuid(),
                FavoritesId = favoritesId,
                ProductId = productId
            };
        }

        public void Update(Product product)
        {
            this.Product = product;
        }
    }
}
