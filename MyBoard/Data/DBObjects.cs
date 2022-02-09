using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {   

            if (!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));

            if (!context.Product.Any())
            {
                context.AddRange
                    (
                    //new Product
                    //{
                    //    name = "Audi",
                    //    shortDesc = "test",
                    //    longDesc = "Test",
                    //    img = "/img/Audi_RS_Q_e-tron_2022_Side.jpg",
                    //    price = 50000,
                    //    isFavorite = true,
                    //    avalible = true,
                    //    Category = Categories["электромобили"]
                    //},

                    //new Product
                    //{
                    //    name = "Porshe",
                    //    shortDesc = "test",
                    //    longDesc = "Test",
                    //    img = "/img/Porsche_Taycan_E-Performance_2021_Silver_color.jpg",
                    //    price = 50000,
                    //    isFavorite = true,
                    //    avalible = true,
                    //    Category = Categories["электромобили"]
                    //},

                    //new Product
                    //{
                    //    name = "Toyota",
                    //    shortDesc = "test",
                    //    longDesc = "Test",
                    //    img = "/img/Toyota_C-HR_Hybrid_C-LUB_(EU-spec)_2021_Hybrid_609077_300x200.jpg",
                    //    price = 50000,
                    //    isFavorite = true,
                    //    avalible = true,
                    //    Category = Categories["электромобили"]
                    //},
                    
                    //new Product
                    //{
                    //    name = "BMW",
                    //    shortDesc = "test",
                    //    longDesc = "Test",
                    //    img = "/img/BMW_X6M_edition_X6_G06_Front_Crossover_White_609644_300x168.jpg",
                    //    price = 50000,
                    //    isFavorite = true,
                    //    avalible = true,
                    //    Category = Categories["классические"]
                    //},
                    
                    new Product
                    {
                        name = "Mercedes-Benz",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Mercedes-Benz_2021_G_400_d_SUV_Blue_609106_300x197.jpg",
                        price = 50000,
                        isFavorite = false,
                        avalible = true,
                        Category = Categories["классические"]
                    }, 
                    
                    new Product
                    {
                        name = "Mercedes-Benz",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Mercedes-Benz_Retro_1952-53_170_Vb_Limousine_Black_609032_300x225.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = Categories["классические"]
                    },
                    
                    new Product
                    {
                        name = "Mitsubishi",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Mitsubishi_Eclipse_Cross_PHEV_Ralliart_Style_2022_609899_300x200.jpg",
                        price = 50000,
                        isFavorite = false,
                        avalible = true,
                        Category = Categories["классические"]
                    }, 
                    
                    new Product
                    {
                        name = "Volkswagen",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Volkswagen_2021_Arteon_4MOTION_R-Line_Red_609426_300x200.jpg",
                        price = 50000,
                        isFavorite = false,
                        avalible = true,
                        Category = Categories["классические"]
                    },
                    
                    new Product
                    {
                        name = "Skoda",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Skoda_Superb_Worldwide)_2002-2006_Blue_Metallic.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = Categories["классические"]
                    }, 
                    
                    new Product
                    {
                        name = "Toyota",
                        shortDesc = "test",
                        longDesc = "Test",
                        img = "/img/Toyota_Tundra_SR_CrewMax_2021_Pickup_Grey_Metallic_608873_300x200.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = true,
                        Category = Categories["классические"]
                    }

                    ); 
            }

            context.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category{categoryName = "электромобили", description = "Новые зеленые технологии"},
                        new Category{categoryName = "классические", description = "Авто с двигателями внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}
