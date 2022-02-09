using MyBoard.Data.Interfaces;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductCategory _productCategory = new MockCategory();

        public IEnumerable<Product> Products 
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        name = "Tesla", 
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Ferrari_296_GTB_(F171)_2022_Red_Metallic_610078_300x200.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = _productCategory.AllCategories.First() 
                    },
                    new Product
                    {
                        name = "Tesla",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Ferrari_296_GTB_(F171)_2022_Red_Metallic_610078_300x200.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = _productCategory.AllCategories.First()
                    },
                    new Product
                    {
                        name = "Tesla",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Ferrari_296_GTB_(F171)_2022_Red_Metallic_610078_300x200.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = _productCategory.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Product> getFavProd { get ; set ; }

        public Product getObjectProd(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
