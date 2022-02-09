using Microsoft.AspNetCore.Mvc;
using MyBoard.Data.Interfaces;
using MyBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAllProducts _prodRep;

        public HomeController(IAllProducts prodRep)
        {
            _prodRep = prodRep;
        }
        public ViewResult Index()
        {
            var homeProduct = new HomeViewModel
            {
                favProduct = _prodRep.getFavProd
            };

            return View(homeProduct);
        }
    }
}
