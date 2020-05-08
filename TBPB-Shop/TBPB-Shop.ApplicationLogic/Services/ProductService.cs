using System;
using System.Collections.Generic;
using System.Linq;
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

        public Product Add(string name, decimal price, int quantityOnStoc, Guid categoryId, Guid producerId)
        {
            return productRepository.Create(name, price, quantityOnStoc, categoryId, producerId);
        }

        public Product Update(string id, string name, decimal price, int quantityOnStoc, Guid categoryId)
        {
            Guid productId = Guid.Empty;
            Guid.TryParse(id, out productId);

            var product = productRepository.GetById(productId);
            product.CreateUpdate(productId, name, price, quantityOnStoc, categoryId);
            return productRepository.Update(product);
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

        public IEnumerable<Product> GetFilteredProducts(string producerId,
                                                        string categoryId,
                                                        string leftPriceInterval,
                                                        string rightPriceInterval)
        {
            if (producerId == "0" && categoryId == "0" && leftPriceInterval == "0" && rightPriceInterval == "0")
            {
                return GetAll();
            }

            Guid guidCategoryId = Guid.Empty;
            Guid.TryParse(categoryId, out guidCategoryId);
            Guid guidProducerId = Guid.Empty;
            Guid.TryParse(producerId, out guidProducerId);
            int intLeftPriceInterval = int.Parse(leftPriceInterval);
            int intRightPriceInterval = int.Parse(rightPriceInterval);
            
            if ((categoryId == "0") && (leftPriceInterval == "0") && (rightPriceInterval == "0"))
            {
                return GetAll().Where(product => product.ProducerId == guidProducerId);
            }

            if ((producerId == "0") && (leftPriceInterval == "0") && (rightPriceInterval == "0"))
            {
                return GetAll().Where(product => product.CategoryId == guidCategoryId);
            }

            if ((producerId == "0") && (categoryId == "0"))
            {
                if (rightPriceInterval == "0")
                {
                    return GetAll().Where(product => product.Price > intLeftPriceInterval);
                }
                return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                                 (product.Price < intRightPriceInterval));
            }

            if (producerId == "0")
            {
                if (rightPriceInterval == "0")
                {
                    return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                                     (product.CategoryId == guidCategoryId));
                }
                return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                                 (product.Price < intRightPriceInterval) &&
                                                 (product.CategoryId == guidCategoryId));
            }

            if (categoryId == "0")
            {
                if (rightPriceInterval == "0")
                {
                    return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                                     (product.ProducerId == guidProducerId));
                }
                return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                                 (product.Price < intRightPriceInterval) &&
                                                 (product.ProducerId == guidProducerId));
            }

            if (leftPriceInterval == "0")
            {
                if (rightPriceInterval == "0")
                {
                    return GetAll().Where(product => (product.CategoryId == guidCategoryId) &&
                                                         (product.ProducerId == guidProducerId));
                }
            }

            return GetAll().Where(product => (product.Price > intLeftPriceInterval) &&
                                             (product.Price < intRightPriceInterval) &&
                                             (product.ProducerId == guidProducerId) &&
                                             (product.CategoryId == guidCategoryId));
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
