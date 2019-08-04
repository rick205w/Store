using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreAPI.Models;
using StoreAPI.ViewModels;

namespace StoreAPI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IEnumerable<ProductViewModel> Get([FromUri] ProductQueryViewModel query)
        {
            var result = new List<ProductViewModel>();
            var datas = DataRepository.GetData();
            if (query != null)
            {
                var shop = datas.FirstOrDefault(o => o.Id == query.ShopId);
                result = shop?.Products.Select(o => new ProductViewModel()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Price = o.Price
                }).ToList();
                return result;
            }

            datas.ForEach(s =>
            {
                s.Products.ForEach(p =>
                {
                    var product = new ProductViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    };
                    result.Add(product);
                });
            });
            return result;
        }

        [HttpPost]
        public void Post(CreateProductsViewModel model)
        {
            DataRepository.AddProducts(model);
        }
    }
}