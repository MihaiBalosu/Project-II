using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;


namespace TBPB_Shop.ApplicationLogic.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private IProductRepository productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public Category Add(string name, string description)
        {
            var product = Category.Create(name, description);
            return categoryRepository.Add(product);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Product> getProductsForCategory(Guid id)
        {
            return categoryRepository.getProductsForCategory(id);
        }

        public void Remove(Guid id)
        {
            var productsForCategory = getProductsForCategory(id);
            productRepository.RemoveList(productsForCategory);
            categoryRepository.Remove(id);  
        }

        public void Update(Guid id, string name, string description)
        {
            var category = categoryRepository.GetById(id);
            category.CreateForUpdate(name, description);
            categoryRepository.Update(category);
        }

        public Category getById(Guid id)
        {
            return categoryRepository.GetById(id);
        }
    }
}
