using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Abstractions
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCartFromUserId(Guid userId);
        void Clear(Guid cartId);
    }
}
