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

        public void CreateForUpdate(string name, string description)
        {

            this.Name = name;
            this.Description = description;
            

        }
    }
}
