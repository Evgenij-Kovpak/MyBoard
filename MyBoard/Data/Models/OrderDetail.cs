using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public double price { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }
    }
}
