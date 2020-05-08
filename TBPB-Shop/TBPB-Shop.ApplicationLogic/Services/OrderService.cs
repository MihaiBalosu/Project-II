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
        private readonly IProductRepository productRepository;
        private readonly CartService cartService;

        public OrderService(IOrderDataRepository orderDataRepository,
                            IProductOrderRepository productOrderRepository,
                            IProductRepository productRepository,
                            CartService cartService)
        {
            this.orderDataRepository = orderDataRepository;
            this.productOrderRepository = productOrderRepository;
            this.productRepository = productRepository;
            this.cartService = cartService;
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
                             string cartId,
                             decimal totalProductsPrice,
                             decimal deliveryPrice,
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
                             string typePayment)
        {
            var orderToCreate = OrderData.Create(customerId,
                                                 totalProductsPrice,
                                                 deliveryPrice,
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
                                                 typePayment);
            orderDataRepository?.Add(orderToCreate);
            AddProductsToOrder(orderToCreate.Id, cartId);

            return orderToCreate;
        }

        public IEnumerable<ProductOrder> AddProductsToOrder(Guid orderId, string cartId)
        {
            var productsCartList = cartService.GetAllProducts(cartId);
            var productsOrderList = new List<ProductOrder>();
            var productsList = new List<Product>();

            foreach (var productCart in productsCartList)
            {
                var productOrder = ProductOrder.Create(productCart.Product.Id, orderId, productCart.Quantity);
                productsOrderList.Add(productOrder);

                var product = productRepository.GetById(productCart.ProductId);
                product.UpdateQuantityOnStoc(productCart.Quantity);
                productsList.Add(product);
            }

            productOrderRepository?.AddProductsList(productsOrderList);
            productRepository?.UpdateProducts(productsList);
            cartService.Clear(cartId);
            return productsOrderList;
        }

        public IEnumerable<OrderData> GetOrdersDataFromCustomer(Customer customer)
        {
            return orderDataRepository.GetAllWithCustomerId(customer.Id);
        }

        public IEnumerable<ProductOrder> GetProductsOrder(string orderId)
        {
            Guid guidOrderId = Guid.Empty;
            Guid.TryParse(orderId, out guidOrderId);

            return productOrderRepository?.GetProductsFromOrder(guidOrderId);
        }
    }
}
