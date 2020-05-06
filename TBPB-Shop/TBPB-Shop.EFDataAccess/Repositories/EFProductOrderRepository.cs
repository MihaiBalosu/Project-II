using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class EFProductOrderRepository : BaseRepository<ProductOrder>, IProductOrderRepository
    {
        public EFProductOrderRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ProductOrder> AddProductsList(IEnumerable<ProductOrder> productsList)
        {
            dbContext.OrderProduct.AddRange(productsList);
            dbContext.SaveChanges();
            return productsList;
        }

        public IEnumerable<ProductOrder> GetProductsFromOrder(Guid orderId)
        {
            var productsOrderList =  dbContext.OrderProduct
                                              .Where(product => product.OrderId == orderId)
                                              .AsEnumerable();
            foreach (var productOrder in productsOrderList)
            {
                var product = dbContext.Products
                                       .Where(p => p.Id == productOrder.ProductId)
                                        .SingleOrDefault();
                productOrder.Update(product);
            }

            return productsOrderList;
        }
    }
}
