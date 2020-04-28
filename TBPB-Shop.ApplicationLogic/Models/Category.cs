using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Category : DataEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }

        private Category()
        { }

        public static Category Create(string name, string description)
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };

            return category;
        }

        public static Category CreateForUpdate(Guid id, string name, string description)
        {
            Category category = new Category
            {
                Id = id,
                Name = name,
                Description = description
            };

            return category;
        }
    }
}
