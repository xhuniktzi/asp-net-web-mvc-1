using asp_net_web_mvc_1.Contracts;
using System;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            var url = $"{Properties.Settings.Default.API}/products";
            var data = JsonConvert.SerializeObject(product);
            var res = ConnectDatabase.ExecPost(url, data, "application/json");
            return JsonConvert.DeserializeObject<Product>(res);
        }

        public void DeleteProduct(string code)
        {
            var url = $"{Properties.Settings.Default.API}/products/{Uri.EscapeDataString(code)}";
            ConnectDatabase.ExecDelete(url);
        }

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

        public void UpdateProduct(string code, Product product)
        {
            var url = $"{Properties.Settings.Default.API}/products/{Uri.EscapeDataString(code)}";
            var data = JsonConvert.SerializeObject(product);
            ConnectDatabase.ExecPut(url, data, "application/json");
        }
    }
}