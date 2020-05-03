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
    public class ProducersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ProducerService producerService;
        private readonly ProductService productService;

        public ProducersController(UserManager<IdentityUser> userManager, ProducerService producerService, ProductService productService)
        {
            this.userManager = userManager;
            this.producerService = producerService;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var producersList = producerService.GetAll();
            return View(producersList);
        }

        public IActionResult GoToProducts(Guid id)
        {
            var producerList = producerService.GetAll();
            var productList = productService.GetAll();
            var viewModel = new ProductsViewModel()
            {
                Products = producerService.getAllProductsFromProducer(id),
                Producers = producerList,
                ProducerId = id
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Create(string name)
        {
            producerService.Add(name);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid Id, string name)
        {
            producerService.Update(Id, name);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateClicked(string Id)
        {
            var producerItem = producerService.GetById(Id);
            return View(producerItem);
        }

        public IActionResult Delete(string Id)
        {
            if(producerService.Remove(Id) == true)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("The deletion could not be performed!");
        }

        
    }
}