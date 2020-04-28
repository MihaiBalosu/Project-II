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

        public CategoriesController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(string name, string description)
        {
            categoryService.Add(name, description);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string name)
        {
            var viewModel = new CategoryViewModel();
            try
            {
                viewModel.Products = categoryService.getProductsForCategory(name);
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest("The deletion coult not be performed!");
            }
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                categoryService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest("The deletion coult not be performed!");
            }
        }

        public IActionResult Edit(Guid id)
        {
            try
            {
                var category = categoryService.GetById(id);
                return View(category);
            }
            catch(Exception e)
            {
                return BadRequest("The action coult not be performed!");
            }
        }

        [HttpPost]
        public IActionResult Edit(Guid id, string name, string description)
        {
            try
            {
                categoryService.Update(id, name, description);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest("The action coult not be performed!");
            }
        }
    }
}
