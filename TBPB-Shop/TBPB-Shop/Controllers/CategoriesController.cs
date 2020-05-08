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
    public class CategoriesController : Controller
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;

        public CategoriesController(CategoryService categoryService, ProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var viewModel = new CategoryViewModel();
            try
            {
                viewModel.Categories = categoryService.GetAll();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewCategoryViewModel viewModel)
        {
            categoryService.Add(viewModel.Name, viewModel.Description);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            try
            {
                var viewModel = new CategoryDetailsViewModel()
                {
                    CategoryName = categoryService.getById(id).Name,
                    Products = categoryService.getProductsForCategory(id)
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        public IActionResult Delete(Guid id)
        {
            categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            try
            {
                var category = categoryService.getById(id);
                var viewModel = new UpdateCategoryViewModel()
                {
                    Name = category.Name,
                    Description = category.Description,
                    CategoryId = category.Id
                };
                return PartialView("_Update", viewModel);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel viewModel)
        {
            categoryService.Update(viewModel.CategoryId, viewModel.Name, viewModel.Description);
            return RedirectToAction("Index");
        }

        public IActionResult GetProducts(Guid id)
        {
            var productsList = categoryService.getProductsForCategory(id);
            return PartialView("_ProductsList", new ProductsForCategoryViewModel { Products = productsList });
        }

        public IActionResult DeleteProduct(string id)
        {
            var categoryId = productService.GetById(id).CategoryId;
            productService.Remove(id);
            return RedirectToAction("Details", new { id = categoryId });
        }
    }
}
