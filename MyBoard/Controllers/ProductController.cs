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
    public class ProductController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductCategory _allCategories;

        public ProductController(IAllProducts iAllProducts, IProductCategory iProductCat)
        {
            _allProducts = iAllProducts;
            _allCategories = iProductCat;
        }
        [Route("Product/List")]
        [Route("Product/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string productCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.Products.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.categoryName.Equals("электромобили"));
                    productCategory = "электромобили";
                }
                else 
                {
                    products = _allProducts.Products.Where(f => f.Category.categoryName.Equals("классическике"));
                    productCategory = "классическике";
                }

            }
            var prodObj = new ProductListViewModel 
            {
                allProduct = products,
                productCategory = productCategory
            };

            ViewBag.Title = "Страница с автомобилями";
            return View(prodObj);
        }
    }
}
