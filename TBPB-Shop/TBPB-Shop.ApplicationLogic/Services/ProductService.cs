using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Exceptions;
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

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product Add(string name, decimal price, int quantityOnStoc, Guid producerId)
        {
            return productRepository.Create(name, price, quantityOnStoc, producerId);
        }

        public Product Update(Guid Id, string name, decimal price, int quantityOnStoc)
        {
            Product productObj = Product.CreateUpdate(Id, name, price, quantityOnStoc);
            return productRepository.Update(productObj);
        }

        public bool Remove(string id)
        {
            Guid productId = Guid.Empty;
            Guid.TryParse(id, out productId);

            if (productId == Guid.Empty)
            {
                throw new ProductException(productId);
            }

            if (productRepository.Remove(productId) == true)
            {
                return true;
            }

            return false;
        }

        public Product GetById(string itemToUpdateId)
        {
            Guid productId = Guid.Empty;
            Guid.TryParse(itemToUpdateId, out productId);

            if (productId == Guid.Empty)
            {
                throw new ProductException(productId);
            }

            return productRepository.GetById(productId);
        }
    }
}
