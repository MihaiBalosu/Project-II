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
        private readonly IProductCartRepository productCartRepository;

        public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, IProductRepository productRepository, IProductCartRepository productCartRepository)
        {
            this.cartRepository = cartRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
            this.productCartRepository = productCartRepository;
        }

        private Guid CheckId(string Id)
        {
            Guid guidCartId = Guid.Empty;
            Guid.TryParse(Id, out guidCartId);

            if (guidCartId == Guid.Empty)
            {
                throw new Exception("Could not parse");
            }

            return guidCartId;
        }

        public Guid GetCartIdByUserId(string userId)
        {
            Guid idToSearch = CheckId(userId);

            var customer = customerRepository?.GetCustomerByUserId(idToSearch);
            if (customer == null)
            {
                throw new Exception();
            }
            return customer.CartId;
        }

        public Cart GetById(string cartId)
        {
            Guid idToSearch = CheckId(cartId);
            return cartRepository?.GetById(idToSearch);
        }

        public IEnumerable<ProductCart> GetAllProducts(string cartId)
        {
            Guid idToSearch = CheckId(cartId);
            return productCartRepository?.GetAllProductsFromCart(idToSearch);
        }

        public ProductCart AddProduct(string cartId, string productId, int quantity)
        {
            Guid guidCartId = CheckId(cartId);
            Guid guidProductId = CheckId(productId);

            var product = productRepository?.GetById(guidProductId);
            if (product == null)
            {
                throw new Exception();
            }

            var cart = GetById(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException(cartId);
            }

            cart.UpdateTotalPrice(product.Price, quantity);
            cart.UpdateNoOfItems();
            cartRepository.Update(cart);

            product.UpdateQuantityOnStoc();
            productRepository.Update(product);

            return productCartRepository?.AddProductToCart(cart, product, quantity);
        }

        public void DeleteProduct(string cartId, string productId)
        {
            Guid guidCartId = CheckId(cartId);
            Guid guidProductId = CheckId(productId);

            var myCart = cartRepository?.GetById(guidCartId);
            if (myCart == null)
            {
                throw new CartNotFoundException(cartId);
            }

            var productCart = productCartRepository?.GetByProductIdCartId(guidCartId, guidProductId);
            if (productCart == null)
            {
                throw new Exception();
            }

            var product = productRepository?.GetById(guidProductId);
            if (product == null)
            {
                throw new Exception();
            }

            myCart.UpdateTotalPrice(product.Price, -productCart.Quantity);
            productCartRepository?.DeleteProductFromCart(guidCartId, guidProductId);
        }

        public void Clear(string cartId)
        {
            Guid idToSearch = Guid.Empty;
            Guid.TryParse(cartId, out idToSearch);

            cartRepository?.Clear(idToSearch);
            productCartRepository?.ClearCart(idToSearch);
        }
    }
}
