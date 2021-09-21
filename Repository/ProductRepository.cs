using asp_net_web_mvc_1.Contracts;
using System;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product FindByCode(string code)
        {
            var url = $"{Properties.Settings.Default.API}/products/{Uri.EscapeDataString(code)}";
            return JsonConvert.DeserializeObject<Product>(ConnectDatabase.ExecGet(url));
        }

        public IEnumerable<Product> GetAll()
        {
            var url = $"{Properties.Settings.Default.API}/products";
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(ConnectDatabase.ExecGet(url));
        }
    }
}