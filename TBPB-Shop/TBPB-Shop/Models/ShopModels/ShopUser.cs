using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.Models.ShopModels
{
    public class ShopUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int NoOfItems { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
