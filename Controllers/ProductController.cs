using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
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

        public ActionResult Details(string code)
        {
            var model = _productRepo.FindByCode(code);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.CreateProduct(product);
                return RedirectToAction("Details", new { code = product.Code });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string code)
        {
            var model = _productRepo.FindByCode(code);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string code, FormCollection form)
        {
            _productRepo.DeleteProduct(code);
            return RedirectToAction("Index");
        }
    }
}