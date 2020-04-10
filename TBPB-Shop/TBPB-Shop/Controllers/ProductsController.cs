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
    public class ProductsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ProductService productService;

        public ProductsController(UserManager<IdentityUser> userManager, ProductService productService)
        {
            this.userManager = userManager;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProductsViewModel();
            try
            {
                viewModel.Products = productService.GetAll();
            }
            catch(Exception e)
            {
                return BadRequest(e);   
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(string name, decimal price, int quantityOnStoc, string categoryId, string producerId)
        {
            productService.Add(name, price, quantityOnStoc, categoryId, producerId);
            return RedirectToAction("Index");
        }
    }
}