using asp_net_web_mvc_1.Models;
using System.Collections.Generic;

namespace asp_net_web_mvc_1.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product FindByCode(string code);
        Product CreateProduct(Product product);
        void DeleteProduct(string code);
        void UpdateProduct(string code, Product product);
    }
}
