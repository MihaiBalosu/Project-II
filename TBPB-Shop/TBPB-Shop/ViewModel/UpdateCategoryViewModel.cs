using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ViewModel
{
    public class UpdateCategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get;  set; }
    }
}
