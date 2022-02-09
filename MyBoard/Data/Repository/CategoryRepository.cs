using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Repository
{
    public class CategoryRepository : IProductCategory
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Category> AllCategories => appDBContext.Category;
    }
}
