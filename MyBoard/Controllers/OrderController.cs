using Microsoft.AspNetCore.Mvc;
using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrder allOrder;
        private readonly ProductCart productCart;

        public OrderController(IAllOrder allOrder, ProductCart productCart)
        {
            this.allOrder = allOrder;
            this.productCart = productCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            productCart.listCartItem = productCart.getCartItems();
            if(productCart.listCartItem.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пустая");
            }

            if (ModelState.IsValid)
            {
                allOrder.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
