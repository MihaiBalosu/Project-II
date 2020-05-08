using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Services
{
    public class FavoritesService
    {
        private readonly IFavoritesRepository favoritesRepository;
        private readonly IProductCartRepository productCartRepository;
        private readonly CartService cartService;

        public FavoritesService(IFavoritesRepository favoritesRepository,
                                CartService cartService,
                                IProductCartRepository productCartRepository)
        {
            this.favoritesRepository = favoritesRepository;
            this.cartService = cartService;
            this.productCartRepository = productCartRepository;
        }

        public Favorites CreateFavoritesForCustomer(Guid customerId)
        {
            var favoritesToCreate = Favorites.Create(customerId);
            favoritesRepository?.Add(favoritesToCreate);
            return favoritesToCreate;
        }

        public Favorites GetByCustomerId(string customerId)
        {
            Guid guidCustomerId = Guid.Empty;
            Guid.TryParse(customerId, out guidCustomerId);
            return favoritesRepository?.GetByCustomerId(guidCustomerId);
        }

        public IEnumerable<ProductFavorites> GetProductsForCustomer(string customerId)
        {
            var favorites = GetByCustomerId(customerId);
            return favoritesRepository?.GetProductsForCustomer(favorites.Id);
        }

        public ProductFavorites MoveProductToFavorites(string productId, string cartId, string customerId)
        {
            Guid guidProductId = Guid.Empty;
            Guid.TryParse(productId, out guidProductId);

            var favorites = GetByCustomerId(customerId);
            var productToAdd = ProductFavorites.Create(favorites.Id, guidProductId);
            cartService.DeleteProduct(cartId, productId);
            return favoritesRepository?.AddProductToFavorites(productToAdd);
        }

        public void RemoveProductFromFavorites(string productId, string customerId)
        {
            Guid guidProductId = Guid.Empty;
            Guid.TryParse(productId, out guidProductId);

            var favorites = GetByCustomerId(customerId);
            favoritesRepository.RemoveProductFromFavorites(favorites.Id, guidProductId);
        }

        public void MoveProductToCart(string productId, string cartId, string customerId)
        {
            cartService.AddProduct(cartId, productId, 1);
            RemoveProductFromFavorites(productId, customerId);
        }
    }
}
