using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Add(string name, decimal price, int quantityOnStoc, string categoryId, string producerId)
        {
            var product = Product.Create(name, price, quantityOnStoc);
            //var category = categoryRepository.GetById(categoryId);
            //category.Products.Add(product)
            return productRepository.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }
    }
}
