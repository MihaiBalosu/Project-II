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
        private readonly ProducerService producerService;

        public ProductsController(UserManager<IdentityUser> userManager, ProductService productService, ProducerService producerService)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.producerService = producerService;
        }

        public IActionResult Index()
        {
            var productList = productService.GetAll();
            var viewModel = new ProductsViewModel()
            {
                Products = productList
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new ProductsCreateUpdateViewModel()
            {
                Producers = producerService.GetAll(),
            };
            return View(viewModel);
        }

        public IActionResult Create(ProductsCreateUpdateViewModel pcuVM)
        {
            try
            {
                productService.Add(pcuVM.Name, pcuVM.Price, pcuVM.QuantityOnStoc, pcuVM.ProducerId);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest("sda");
            }
        }

        public IActionResult UpdateClicked(string Id)
        {
            var productItem = productService.GetById(Id);
            
            return View(productItem);
        }

        public IActionResult Details(string Id)
        {
            var productItem = productService.GetById(Id);

            return View(productItem);
        }

        public IActionResult Update(Guid Id, ProductsCreateUpdateViewModel pcuVM)
        {
            productService.Update(Id, pcuVM.Name, pcuVM.Price, pcuVM.QuantityOnStoc);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string Id)
        {
            if (productService.Remove(Id) == true)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("The deletion coult not be performed!");
        }
    }
}