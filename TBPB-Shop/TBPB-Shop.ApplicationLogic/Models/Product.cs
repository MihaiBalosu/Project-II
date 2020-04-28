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
        public Guid producerId { get; set; }

        public decimal WarrantyOneYear { get; private set; }
        public decimal WarrantyTwoYears { get; private set; }
        


        private Product()
        { }

        public static Product Create(string name, decimal price, int quantityOnStoc, Guid producerID)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                QuantityOnStoc = quantityOnStoc,
                producerId = producerID
                QuantityOnStoc = quantityOnStoc,
                WarrantyOneYear = price / 10,
                WarrantyTwoYears = (price * 17) / 100
            };
            return product;
        }

        public static Product CreateUpdate(Guid Id, string name, decimal price, int quantityOnStoc)
        {
            Product product = new Product
            {
                Id = Id,
                Name = name,
                Price = price,
                QuantityOnStoc = quantityOnStoc,
                WarrantyOneYear = price / 10,
                WarrantyTwoYears = (price * 17) / 100
            };
            return product;
        }

        public int UpdateQuantityOnStoc()
        {
            this.QuantityOnStoc--;
            return this.QuantityOnStoc;
        }
    }
}
