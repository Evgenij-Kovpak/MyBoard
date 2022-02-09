using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Mocks
{
    public class MockCategory : IProductCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "электромобили", description = "Test"},
                    new Category{categoryName = "diesel", description = "Test1"}
                };
            }
        }

    }
}
