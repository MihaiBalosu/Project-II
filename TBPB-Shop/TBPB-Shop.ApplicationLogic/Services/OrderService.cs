using System;
using System.Collections.Generic;
using System.Text;
using TBPB_Shop.ApplicationLogic.Abstractions;
using TBPB_Shop.ApplicationLogic.Models;

namespace TBPB_Shop.ApplicationLogic.Services
{
    public class OrderService
    {
        private readonly IOrderDataRepository orderDataRepository;
        private readonly IProductOrderRepository productOrderRepository; 

        public OrderService(IOrderDataRepository orderDataRepository, IProductOrderRepository productOrderRepository)
        {
            this.orderDataRepository = orderDataRepository;
            this.productOrderRepository = productOrderRepository;
        }

        public OrderData GetById(string id)
        {
            Guid orderId = Guid.Empty;
            Guid.TryParse(id, out orderId);

            return orderDataRepository?.GetById(orderId);
        }

        public IEnumerable<OrderData> GetAll()
        {
            return orderDataRepository?.GetAll();
        }

        public OrderData Add(Guid customerId,
                             decimal totalPrice,
                             string typeDelivery,
                             string nameDelivery,
                             string phoneDelivery,
                             string cityDelivery,
                             string districtDelivery,
                             string addressDelivery,
                             string typeBilling,
                             string nameBilling,
                             string phoneBilling,
                             string cityBilling,
                             string districtBilling,
                             string addressBilling,
                             string typePayment,
                             string nameCardPayment,
                             string amountCardPayemnt,
                             string cvvCardPayment,
                             string numberCardPayemnt,
                             DateTime expireDateCardPayment,
                             IEnumerable<ProductCart> productsCartList)
        {
            var orderToCreate = OrderData.Create(customerId,
                                                 totalPrice,
                                                 typeDelivery,
                                                 nameDelivery,
                                                 phoneDelivery,
                                                 cityDelivery,
                                                 districtDelivery,
                                                 addressDelivery,
                                                 typeBilling,
                                                 nameBilling,
                                                 phoneBilling,
                                                 cityBilling,
                                                 districtBilling,
                                                 addressBilling,
                                                 typePayment,
                                                 nameCardPayment,
                                                 amountCardPayemnt,
                                                 cvvCardPayment,
                                                 numberCardPayemnt,
                                                 expireDateCardPayment);
            orderDataRepository?.Add(orderToCreate);
            var productsOrderList = new List<ProductOrder>();
            
            foreach (var productCart in productsCartList)
            {
                var productOrder = ProductOrder.Create(productCart.Id, orderToCreate.Id);
                productsOrderList.Add(productOrder);
            }
            productOrderRepository?.AddProductsList(productsOrderList);
            return orderToCreate;
        }

        public IEnumerable<OrderData> GetOrdersDataFromCustomer(Customer customer)
        {
            return orderDataRepository.GetAllWithCustomerId(customer.Id);
        }
    }
}
