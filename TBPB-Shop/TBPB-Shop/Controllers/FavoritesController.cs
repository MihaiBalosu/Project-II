using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TBPB_Shop.ApplicationLogic;
using TBPB_Shop.ApplicationLogic.Services;
using TBPB_Shop.ViewModel;

namespace TBPB_Shop.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly FavoritesService favoritesService;
        private readonly CartService cartService;
        private readonly CustomerService customerService;

        public FavoritesController(FavoritesService favoritesService,
                                   UserManager<IdentityUser> userManager,
                                   CartService cartService,
                                   CustomerService customerService)
        {
            this.favoritesService = favoritesService;
            this.userManager = userManager;
            this.cartService = cartService;
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            string userId = userManager.GetUserId(User);
            var customer = customerService.GetCustomerByUserId(userId);
            var viewModel = new ProductsFavoritesViewModel
            {
                Products = favoritesService.GetProductsForCustomer(customer.Id.ToString())
            };

            return View(viewModel);
        }

        public IActionResult AddProduct(string productId)
        {
            var userId = userManager.GetUserId(User);
            var cartId = cartService.GetCartIdByUserId(userId);
            var customer = customerService.GetCustomerByUserId(userId);

            favoritesService.MoveProductToFavorites(productId, cartId.ToString(), customer.Id.ToString());
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProduct(string productId)
        {
            var userId = userManager.GetUserId(User);
            var customer = customerService.GetCustomerByUserId(userId);
            favoritesService.RemoveProductFromFavorites(productId, customer.Id.ToString());
            return RedirectToAction("Index");
        }

        public IActionResult MoveToCart(string productId)
        {
            var userId = userManager.GetUserId(User);
            var customer = customerService.GetCustomerByUserId(userId);
            var cartId = cartService.GetCartIdByUserId(userId);

            favoritesService.MoveProductToCart(productId, cartId.ToString(), customer.Id.ToString());
            return RedirectToAction("Index", "Cart");
        }
    }
}