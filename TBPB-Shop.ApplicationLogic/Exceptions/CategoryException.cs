using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Exceptions
{
    class CategoryException : Exception
{
        public Guid categoryId { get; private set; }

        public CategoryException(Guid id) : base($"Category with id {id} was not found!")
        {
            categoryId = id;
        }
    }
}
