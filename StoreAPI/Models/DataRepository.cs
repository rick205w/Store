using System.Collections.Generic;
using System.Linq;
using StoreAPI.ViewModels;

namespace StoreAPI.Models
{
    static class DataRepository
    {
        private static List<Shop> Data = new List<Shop>()
        {
            new Shop()
            {
                Id = 1,
                Name = "Wastons",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "歐芮坦 細柔抽取式衛生紙 100抽10包入",
                        Price = 79
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "屈臣氏抽取式衛生紙110抽10包入",
                        Price = 109
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "舒潔棉柔舒適抽取衛生紙90抽x8包(蠶絲蛋白)",
                        Price = 109
                    }
                }
            },
            new Shop()
            {
                Id = 2,
                Name = "Cosmed",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Id = 4,
                        Name = "好奇純水嬰兒濕巾迪士尼厚型70抽",
                        Price = 39
                    },

                    new Product()
                    {
                        Id = 5,
                        Name = "COSMED柔膚濕巾(10片)10入組",
                        Price = 89
                    },
                    new Product()
                    {
                        Id = 6,
                        Name = "舒潔袖珍包面紙10抽28包",
                        Price = 99
                    }
                }
            }
        };

        public static List<Shop> GetData()
        {
            return Data;
        }

        public static void AddProducts(CreateProductsViewModel model)
        {
            var shop = Data.FirstOrDefault(o => o.Id == model.ShopId);
            model.Products.ForEach(o =>
            {
                var newProduct = new Product()
                {
                    Name = o.Name,
                    Price = o.Price,
                    Id = 1 + Data.Max(s =>
                    {
                        int maxId = s.Products.Max(x => x.Id);
                        return maxId;
                    })
                };
                shop.Products.Add(newProduct);
            });
        }
    }
}