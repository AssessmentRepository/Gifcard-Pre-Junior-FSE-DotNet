using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GiftCards.Controllers
{
    public class ViewOrderController : Controller
    {
        public IActionResult ViewAllOrders()
        {

            //Do code here
            return View();
        }
    }
}