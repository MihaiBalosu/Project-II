using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBPB_Shop.ApplicationLogic.Models
{
    public class Customer: DataEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }

        public static Customer Create(Guid userId, string firstName, string lastName, Guid cartId)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                FirstName = firstName,
                SecondName = lastName,
                CartId = cartId
            };
        }
    }
}
