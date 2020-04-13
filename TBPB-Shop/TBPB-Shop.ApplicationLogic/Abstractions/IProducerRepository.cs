using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IProducerRepository : IRepository<Producer>
    {
        Producer Create(string name);
        void AddProductToProducer(Guid Id, Guid producerId);
    }
}
