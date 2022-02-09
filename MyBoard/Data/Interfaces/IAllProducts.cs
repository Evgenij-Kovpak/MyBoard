using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavProd { get; }
        Product getObjectProd(int productId);
    }
}
