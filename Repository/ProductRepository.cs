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
        public IEnumerable<Product> GetAll()
        {
            var url = $"{Properties.Settings.Default.API}/products";
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Accept = "application/json";
            try
            {
                using(WebResponse res = req.GetResponse())
                {
                    using(StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<Product>>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
                throw;
            }
        }
    }
}