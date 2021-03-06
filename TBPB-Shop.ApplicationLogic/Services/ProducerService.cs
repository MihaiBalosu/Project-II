﻿using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Exceptions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Services
{
    public class ProducerService
    {
        private readonly IProducerRepository producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            this.producerRepository = producerRepository;
        }

        public IEnumerable<Producer> GetAll()
        {
            return producerRepository.GetAll();
        }

        public Producer Add(string name)
        {
            return producerRepository.Create(name);
        }

        public Producer Update(Guid Id, string name)
        {
            Producer producerObj = Producer.CreateUpdate(Id, name);
            return producerRepository.Update(producerObj);
        }

        public bool Remove(string id)
        {
            Guid producerId = Guid.Empty;
            Guid.TryParse(id, out producerId);

            if(producerId == Guid.Empty)
            {
                throw new ProducerException(producerId);
            }

            if(producerRepository.Remove(producerId) == true)
            {
                return true;
            }
            return false;
        }

        public Producer GetById(string itemToUpdateId)
        {
            Guid producerId = Guid.Empty;
            Guid.TryParse(itemToUpdateId, out producerId);

            if(producerId == Guid.Empty)
            {
                throw new ProducerException(producerId);
            }
            return producerRepository.GetById(producerId);
        }

        public IEnumerable<Product> GetAllProductsFromProducer(string Id)
        {
            var producer = GetById(Id);
            return producer.Products;
        }
    }
}
