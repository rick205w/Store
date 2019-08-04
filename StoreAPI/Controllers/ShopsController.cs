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
    public class ShopsController : ApiController
    {
        [HttpGet]
        public IEnumerable<ShopViewModel> Get()
        { 
            var datas = DataRepository.GetData();
            var result = datas.Select(o => new ShopViewModel()
            {
                Id = o.Id,
                Name = o.Name
            }).ToList();
            return result;
        }
    }
}