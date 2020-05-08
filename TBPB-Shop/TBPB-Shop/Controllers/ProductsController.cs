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
        private readonly CategoryService categoryService;
        private readonly FavoritesService favoritesService;

        public ProductsController(UserManager<IdentityUser> userManager,
                                  ProductService productService,
                                  ProducerService producerService,
                                  CategoryService categoryService,
                                  FavoritesService favoritesService)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.producerService = producerService;
            this.categoryService = categoryService;
            this.favoritesService = favoritesService;
        }

        public IActionResult Index()
        {
            var producerList = producerService.GetAll();
            var productList = productService.GetAll();
            var categoryList = categoryService.GetAll();

            var viewModel = new ProductsViewModel()
            {
                Products = productList,
                Producers = producerList,
                Categories = categoryList
            };
            return View(viewModel);
        }

        public IActionResult Filter(string producerId,
                                    string categoryId,
                                    string leftPriceInterval,
                                    string rightPriceInterval)
        {
            var productsList = productService.GetFilteredProducts(producerId,
                                                                  categoryId,
                                                                  leftPriceInterval,
                                                                  rightPriceInterval);
            return PartialView("_ProductsList", new FilteredProductsViewModel { Products = productsList });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductsCreateUpdateViewModel()
            {
                Producers = producerService.GetAll(),
                Categories = categoryService.GetAll()
            };
            return PartialView("_Create", viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductsCreateUpdateViewModel pcuVM)
        {
            try
            {
                productService.Add(pcuVM.Name, pcuVM.Price, pcuVM.QuantityOnStoc, pcuVM.CategoryId, pcuVM.ProducerId);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest("sda");
            }
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var productItem = productService.GetById(id);
            var viewModel = new ProductsCreateUpdateViewModel
            {
                ProductId = id,
                Name = productItem.Name,
                Price = productItem.Price,
                QuantityOnStoc = productItem.QuantityOnStoc,
                Categories = categoryService.GetAll()
            };
            return PartialView("_Update", viewModel);
        }

        public IActionResult Details(string Id)
        {
            var productItem = productService.GetById(Id);
            return View(productItem);
        }

        [HttpPost]
        public IActionResult Update(ProductsCreateUpdateViewModel pcuVM)
        {
            productService.Update(pcuVM.ProductId, pcuVM.Name, pcuVM.Price, pcuVM.QuantityOnStoc, pcuVM.CategoryId);
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