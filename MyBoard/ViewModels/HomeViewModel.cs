using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> favProduct { get; set; }
    }
}
