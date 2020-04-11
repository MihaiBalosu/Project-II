﻿using System;
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

        private Product()
        { }

        public static Product Create(string name, decimal price, int quantityOnStoc)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                QuantityOnStoc = quantityOnStoc
            };


            return product;
        }
    }
}
