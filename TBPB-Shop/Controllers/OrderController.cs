using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TBPB_Shop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}