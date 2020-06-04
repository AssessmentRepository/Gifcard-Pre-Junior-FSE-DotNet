using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftCards.BusinessLayer.Interface;
using GiftCards.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GiftCards.Controllers
{
    public class BuyerController : Controller
    {
        public readonly IBuyerServices _service;

        public BuyerController(IBuyerServices service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Buyer buyer)
        {
            try
            {
                // TODO: Add insert logic here
                await _service.RegisterAsync(buyer);
                return RedirectToAction(nameof(AllBuyer));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> AllBuyer()
        {

            var Buyer = await _service.GetAllBuyersAsync();
            return View(Buyer);
        }

        public async Task<IActionResult> PlaceGiftOrderAsync(GiftOrder Order)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<IActionResult> ChangePassword(int BuyerId)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetBuyerByIdAsync(int BuyerId)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Login(Buyer buyer)
        {

            //Do code here
            throw new NotImplementedException();
        }

        public async Task<IActionResult> LogOut(Buyer buyer)
        {

            //Do code here
            throw new NotImplementedException();
        }

    }
}