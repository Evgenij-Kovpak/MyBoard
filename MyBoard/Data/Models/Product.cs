using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public string img { get; set; }
        public double price { get; set; }
        public bool isFavorite { get; set; }
        public bool avalible { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
