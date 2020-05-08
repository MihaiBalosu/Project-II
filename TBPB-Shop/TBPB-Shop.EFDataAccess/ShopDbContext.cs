using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {}

        public DbSet<OrderData> Orders { get; private set; }
        public DbSet<ProductOrder> OrderProduct { get; private set; }
        public DbSet<Cart> Carts { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        public DbSet<Category> Categories{ get; private set; }
        public DbSet<Producer> Producers { get; private set; }
        public DbSet<Product> Products{ get; private set; }
        public DbSet<ProductCart> ProductCart { get; private set; }
        public DbSet<Favorites> Favorites { get; private set; }
        public DbSet<ProductFavorites> ProductFavorites { get; private set; }
    }
}
