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
            var viewModel = new ProducerViewModel
            {
                Producers = producerService.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateProducerViewModel viewModel)
        {
            producerService.Add(viewModel.Name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(CreateUpdateProducerViewModel viewModel)
        {
            producerService.Update(viewModel.ProducerId, viewModel.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string Id)
        {
            var producerDb = producerService.GetById(Id);
            var viewModel = new CreateUpdateProducerViewModel
            {
                Name = producerDb.Name,
                ProducerId = producerDb.Id
            };
            
            return PartialView("_Update", viewModel);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                producerService.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Details(string id)
        {
            var producerDb = producerService.GetById(id);
            var viewModel = new ProducerDetailsViewModel
            {
                ProducerName = producerDb.Name,
                Products = producerService.getAllProductsFromProducer(producerDb.Id)
            };
            return View(viewModel); 
        }

        public IActionResult DeleteProduct(string id)
        {
            var producerId = productService.GetById(id).ProducerId;
            productService.Remove(id);
            return RedirectToAction("Details", new { id = producerId});
        }
        
    }
}