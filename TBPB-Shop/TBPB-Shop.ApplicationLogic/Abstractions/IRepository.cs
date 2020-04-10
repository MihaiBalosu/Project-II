using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface IRepository<T> where T: DataEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        T Update(T entity);
        bool Remove(Guid id);
    }
}
