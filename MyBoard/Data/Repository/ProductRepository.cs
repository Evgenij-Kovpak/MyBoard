using Microsoft.EntityFrameworkCore;
using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContext appDBContext;

        public ProductRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Product> Products => appDBContext.Product.Include(c => c.Category);

        public IEnumerable<Product> getFavProd => appDBContext.Product.Where(p => p.isFavorite).Include(c => c.Category);

        public Product getObjectProd(int productId) => appDBContext.Product.FirstOrDefault(p => p.id == productId);
    }
}
