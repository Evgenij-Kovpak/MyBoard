using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> allProduct { get; set; }

        public string productCategory { get; set; }
    }
}
