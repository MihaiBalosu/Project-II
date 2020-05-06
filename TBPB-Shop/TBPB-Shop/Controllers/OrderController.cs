using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TBPB_Shop.ApplicationLogic;
using TBPB_Shop.ApplicationLogic.Services;
using TBPB_Shop.ViewModel;

namespace TBPB_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly CartService cartService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly CustomerService customerService;

        public OrderController(OrderService orderService,
                               UserManager<IdentityUser> userManager,
                               CartService cartService,
                               CustomerService customerService)
        {
            this.orderService = orderService;
            this.userManager = userManager;
            this.cartService = cartService;
            this.customerService = customerService;
        }

        public IActionResult Create()
        {
            string userId = userManager.GetUserId(User);
            try
            {
                var cartId = cartService.GetCartIdByUserId(userId);
                var myCart = cartService.GetById(cartId.ToString());
                var deliveryPrice = ((myCart.TotalPrice > 250) ? 0 : 30 - (myCart.TotalPrice * 3 / 25));

                var viewModel = new OrderViewModel
                {
                    TotalProductsPrice = myCart.TotalPrice,
                    DeliveryPrice = deliveryPrice,
                    TotalPrice = myCart.TotalPrice + deliveryPrice
                };
                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel viewModel)
        {
            try
            {
                var userId = userManager.GetUserId(User);
                var customer = customerService.GetCustomerByUserId(userId);
                var cartId = cartService.GetCartIdByUserId(userId);
                var productsList = cartService.GetAllProducts(cartId.ToString());

                orderService.Add(customer.Id,
                                 10,
                                 viewModel.TypeDelivery,
                                 viewModel.NameDelivery,
                                 viewModel.PhoneDelivery,
                                 viewModel.CityDelivery,
                                 viewModel.DistrictDelivery,
                                 viewModel.AddressDelivery,
                                 viewModel.TypeBilling,
                                 viewModel.NameBilling,
                                 viewModel.PhoneBilling,
                                 viewModel.CityBilling,
                                 viewModel.DistrictBilling,
                                 viewModel.AddressBilling,
                                 viewModel.TypePayment,
                                 viewModel.NameCardPayment,
                                 viewModel.AmountCardPayment,
                                 viewModel.CVVCardPayment,
                                 viewModel.NumberCardPayment,
                                 viewModel.ExpireDateCardPayment,
                                 productsList);
                return View();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult History()
        {
            var userId = userManager.GetUserId(User);
            try
            {
                var customer = customerService.GetCustomerByUserId(userId);
                var viewModel = new OrdersDataViewModel
                {
                    Orders = orderService.GetOrdersDataFromCustomer(customer)
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}