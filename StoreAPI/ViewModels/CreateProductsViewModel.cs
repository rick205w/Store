using System.Collections.Generic;

namespace StoreAPI.ViewModels
{
    public class CreateProductsViewModel
    {
        public int ShopId { get; set; }
        public List<Product> Products { get; set; }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}