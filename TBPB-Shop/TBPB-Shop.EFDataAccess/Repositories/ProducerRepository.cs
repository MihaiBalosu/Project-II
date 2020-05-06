using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.EFDataAccess.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        private readonly IProductRepository prodRepository;
        public ProducerRepository(ShopDbContext dbContext, IProductRepository prodRepository) : base(dbContext)
        {
            this.prodRepository = prodRepository;
        }

        public Producer Create(string name)
        {
            Producer prod = Producer.Create(name);
            return Add(prod);
        }

        public IEnumerable<Product> getAllProductsFromProducer(Guid id)
        {
            return dbContext.Products.Where(product => product.producerId == id).AsEnumerable();
        }
    }
}
