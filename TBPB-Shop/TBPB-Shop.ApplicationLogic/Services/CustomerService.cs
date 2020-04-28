using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomerByUserId(string userId)
        {
            Guid guidUserId = Guid.Empty;
            Guid.TryParse(userId, out guidUserId);

            if (guidUserId == Guid.Empty)
            {
                throw new Exception("");
            }

            var customer = customerRepository.GetCustomerByUserId(guidUserId);

            if (customer == null)
            {
                throw new CustomerNotFoundException(customer.Id);
            }

            return customer;
        }

        public Customer RegisterNewCustomer(string userId, string firstName, string lastName, Guid cartId)
        {
            Guid guidUserId = Guid.Empty;
            Guid.TryParse(userId, out guidUserId);

            Customer newCustomer = Customer.Create(guidUserId, firstName, lastName, cartId);
            return customerRepository?.Add(newCustomer);
        }
    }
}
