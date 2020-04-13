using System;
using System.Collections.Generic;
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

        public void AddProductToProducer(Guid Id, Guid ProducerId)
        {
            Product prodObj = prodRepository.GetById(Id);
            Producer producerObj = GetById(ProducerId);
            producerObj.AddProductToList(prodObj);
        }

    }
}
