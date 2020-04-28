using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
                    TotalPriceProducts = myCart.TotalPrice,
                    PriceDelivery = 23,
                    TotalPrice = myCart.TotalPrice + 23,
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Cart/Delete/{productId}")]
        public IActionResult Delete(string productId)
        {
            string userId = userManager.GetUserId(User);
            try
            {
                var cartId = cartService.GetCartIdByUserId(userId);
                cartService.DeleteProduct(cartId.ToString(), productId);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult UpdateQuantity(string productId, string quantity)
        {
            string userId = userManager.GetUserId(User);
            try
            {
                var cartId = cartService.GetCartIdByUserId(userId);
                cartService.UpdateQuantityOnProduct(cartId.ToString(), productId, quantity);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTotalPrice()
        {
            var priceDelivery = new Decimal(22.11);

            var userId = userManager.GetUserId(User);
            var myCartId = cartService.GetCartIdByUserId(userId);
            var myCart = cartService.GetById(myCartId.ToString());

            var viewModel = new CartViewModel
            {
                TotalPriceProducts = myCart.TotalPrice,
                PriceDelivery = priceDelivery,
                TotalPrice = myCart.TotalPrice + priceDelivery 
            };
            return PartialView("_GetTotalPrice", viewModel);
        }

        [HttpGet]
        public IActionResult SubGetTotalPrice()
        {
            var priceDelivery = new Decimal(22.11);

            var userId = userManager.GetUserId(User);
            var myCartId = cartService.GetCartIdByUserId(userId);
            var myCart = cartService.GetById(myCartId.ToString());

            var viewModel = new CartViewModel
            {
                TotalPriceProducts = myCart.TotalPrice,
                PriceDelivery = priceDelivery,
                TotalPrice = myCart.TotalPrice + priceDelivery
            };
            return PartialView("_SubGetTotalPrice", viewModel);
        }

        public IActionResult ContactForm()
        {
            return PartialView("_ContactForm");
        }

    }
}