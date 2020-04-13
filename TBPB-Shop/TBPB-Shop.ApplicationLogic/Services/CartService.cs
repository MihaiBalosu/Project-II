using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Exceptions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Services
{
    public class CartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository productRepository;

        public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
        }

        private Guid CheckId(string cartId)
        {
            if (cartId == null)
            {
                throw new CartNotFoundException(cartId);
            }

            Guid guidCartId = Guid.Empty;
            Guid.TryParse(cartId, out guidCartId);

            return guidCartId;
        }

        public Guid GetCartIdByUserId(string userId)
        {
            Guid idToSearch = Guid.Empty;
            Guid.TryParse(userId, out idToSearch);

            var customer = customerRepository.GetCustomerByUserId(idToSearch);
            return customer.CartId;
        }

        public Cart GetById(string cartId)
        {
            return cartRepository?.GetById(CheckId(cartId));
        }

        public IEnumerable<ProductCart> GetAllProducts(Guid cartId)
        {
            return cartRepository?.GetAllProducts(cartId);
        }

        public ProductCart AddProduct(Guid cartId, string productId, int quantity)
        {
            var product = productRepository.GetById(CheckId(productId));
            return cartRepository?.AddProduct(cartId, product, quantity);
        }

        public ProductCart DeleteProduct(string cartId, Product product)
        {
            return cartRepository?.DeleteProduct(CheckId(cartId), product.Id);
        }

        public ProductCart UpdateProductQuantity(string cartId, int quantity, Product product)
        {
            return cartRepository?.UpdateProductQuantity(CheckId(cartId), product.Id, quantity);
        }
    }
}
