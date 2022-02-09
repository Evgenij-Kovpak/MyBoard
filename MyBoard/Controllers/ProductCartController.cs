using Microsoft.AspNetCore.Mvc;
using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using MyBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Controllers
{
    public class ProductCartController : Controller
    {
        private readonly IAllProducts _prodRep;
        private readonly ProductCart _prodCart;

        public ProductCartController(IAllProducts prodRep, ProductCart prodCart)
        {
            _prodRep = prodRep;
            _prodCart = prodCart;
        }

        public ViewResult Index()
        {
            var items = _prodCart.getCartItems();
            _prodCart.listCartItem = items;

            var obj = new ProductCartViewModel
            {
                productCart = _prodCart
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _prodRep.Products.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _prodCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
