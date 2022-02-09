using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        List<Product> products { get; set; }
    }
}
