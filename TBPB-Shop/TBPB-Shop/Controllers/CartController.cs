using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TBPB_Shop.ApplicationLogic.Services;
using TBPB_Shop.ViewModel;

namespace TBPB_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly CartService cartService;

        public CartController(UserManager<IdentityUser> userManager, CartService cartService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
        }
        public IActionResult Index()
        {
            string userId = userManager.GetUserId(User);
            try
            {
                var cartId = cartService.GetCartIdByUserId(userId);
                var myCart = cartService.GetById(cartId.ToString());

                var viewModel = new CartViewModel
                {
                    CartId = cartId,
                    Products = cartService.GetAllProducts(cartId.ToString()),
                    NoOfProducts = myCart.NoOfItems,
                    TotalPrice = myCart.TotalPrice
                };

                return View(viewModel);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult AddProduct(string id)
        {
            string userId = userManager.GetUserId(User);
            try
            {
                var cartId = cartService.GetCartIdByUserId(userId);
                cartService.AddProduct(cartId.ToString(), id, 1);
                return RedirectToAction("Index", "Products");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Clear(string id)
        {
            try
            {
                cartService.Clear(id);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}