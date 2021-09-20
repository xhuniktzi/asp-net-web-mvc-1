using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Repository;
using System.Web.Mvc;

namespace asp_net_web_mvc_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController()
        {
            _productRepo = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = _productRepo.GetAll();
            return View(model);
        }
    }
}