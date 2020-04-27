using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TBPB_Shop.ApplicationLogic.Services;

namespace TBPB_Shop.Controllers
{
    public class ProducersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ProducerService producerService;

        public ProducersController(UserManager<IdentityUser> userManager, ProducerService producerService)
        {
            this.userManager = userManager;
            this.producerService = producerService;
        }

        public IActionResult Index()
        {
            var producersList = producerService.GetAll();
            return View(producersList);
        }

        public IActionResult GoToProducts(Guid id)
        {
            return View(producerService.getAllProductsFromProducer(id));
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