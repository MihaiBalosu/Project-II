using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ViewModel
{
    public class CardViewModel
    {
        [Display(Name = "Titular name")]
        public string TitularName { get; set; }
        public decimal Amount { get; set; }
        public string CVV { get; set; }

        [Display(Name = "Card number")]
        public string CardNumber { get; set; }

        [Display(Name = "Expire date")]
        public string ExpireDate { get; set; }
    }
}