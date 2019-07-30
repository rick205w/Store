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
        public IEnumerable<ProductViewModel> Get()
        {
            var result = new List<ProductViewModel>();
            var datas = DataRepository.GetDatas();
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
    }
}