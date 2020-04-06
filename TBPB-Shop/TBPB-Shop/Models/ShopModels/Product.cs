using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.Models.ShopModels
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public string ID { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(160, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Range(0.1, 100000, ErrorMessage = "Price must be higher than 0.1 and less then 100000!")]
        public decimal Price { get; set; }

        [DisplayName("Category")]
        public string CategoryID { get; set; }
        public Category Category { get; set; }

        [DisplayName("Producer")]
        public string ProducerID { get; set; }
        public Producer Producer { get; set; }
    }
}
