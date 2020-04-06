using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPBShop.Models.ShopModels
{
    public class ShopUser : IdentityUser
    {
        public int NoOfItems { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
