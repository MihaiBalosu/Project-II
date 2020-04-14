using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Exceptions;
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

        public IEnumerable<Product> getProductsForCategory(string name)
        {
            return categoryRepository.getProductsForCategory(name);
        }

        public void Remove(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new CategoryException(id);
            }

            categoryRepository.Remove(id);
        }

        public void Update(Guid id, string name, string description)
        {
            Category category = Category.CreateForUpdate(id, name, description);
            categoryRepository.Update(category);
        }

        public Category GetById(Guid id)
        {
        
            if (id == Guid.Empty)
            {
                throw new CategoryException(id);
            }

            return categoryRepository.GetById(id);
        }
    }
}
