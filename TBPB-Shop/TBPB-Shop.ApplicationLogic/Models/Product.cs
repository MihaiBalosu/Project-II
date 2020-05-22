using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models{
    public class Product: DataEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnStoc { get; private set; }
        public Producer Producer { get; private set; }
        public Guid ProducerId { get; set; }
        public Category Category { get; private set; }
        public Guid CategoryId { get; set; }
        public decimal WarrantyOneYear { get; private set; }
        public decimal WarrantyTwoYears { get; private set; }

        private Product()
        { }

        public static Product Create(string name, decimal price, int quantityOnStoc, Guid categoryId,  Guid producerID)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                QuantityOnStoc = quantityOnStoc,
                WarrantyOneYear = price / 10,
                WarrantyTwoYears = (price * 17) / 100,
                CategoryId = categoryId,
                ProducerId = producerID
            };
            return product;
        }

        public Product CreateUpdate(string name, decimal price, int quantityOnStoc, Guid categoryId)
        {
            this.Name = name;
            this.Price = price;
            this.QuantityOnStoc = quantityOnStoc;
            this.WarrantyOneYear = price / 10;
            this.WarrantyTwoYears = (price * 17) / 100;
            this.CategoryId = categoryId;
            return this;
        }

        public int UpdateQuantityOnStoc(int quantity)
        {
            this.QuantityOnStoc -= quantity;
            return this.QuantityOnStoc;
        }
    }
}