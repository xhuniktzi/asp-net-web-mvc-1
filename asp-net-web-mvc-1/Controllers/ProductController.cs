using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.ErrorHandling;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
using System.Web.Mvc;
using System.Linq;

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
        public ActionResult Index(string NameSortOrder)
        {
            if (string.IsNullOrEmpty(NameSortOrder))
            {
                ViewBag.NameSortParam = "asc";
                var model = _productRepo.GetAll();
                return View(model);
            } else if (NameSortOrder == "asc")
            {
                ViewBag.NameSortParam = "desc";
                var model = from product in _productRepo.GetAll()
                            orderby product.Name ascending
                            select product;
                return View(model);
            } else if (NameSortOrder == "desc")
            {
                ViewBag.NameSortParam = "asc";
                var model = from product in _productRepo.GetAll()
                            orderby product.Name descending
                            select product;
                return View(model);
            }
            else
            {
                var model = _productRepo.GetAll();
                return View(model);
            }
        }

        public ActionResult Details(string code)
        {
            var model = _productRepo.FindByCode(code);
            if (model == null)
            {
                TempData["Error"] = "El producto no existe";
                return RedirectToAction("Index");
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
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepo.CreateProduct(product);
                    TempData["Success"] = $"Producto {product.Code} - {product.Name} creado correctamente";
                    return RedirectToAction("Details", new { code = product.Code });
                }
                return View();
            } catch (ApiException ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(product);
            }
           
        }

        [HttpGet]
        public ActionResult Edit(string code)
        {            
            var model = _productRepo.FindByCode(code);
            if (model == null)
            {
                TempData["Error"] = "El producto no existe";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string codeProduct, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepo.UpdateProduct(codeProduct, product);
                    TempData["Success"] = $"Producto {product.Code} - {product.Name} actualizado correctamente";
                    return RedirectToAction("Details", new { code = product.Code });
                }
                return View(product);
            }
            catch (ApiException ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(string code)
        {
            var model = _productRepo.FindByCode(code);
            if (model == null)
            {
                TempData["Error"] = "El producto no existe";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string code, FormCollection form)
        {
            try
            {
                var model = _productRepo.FindByCode(code);
                _productRepo.DeleteProduct(code);
                TempData["Success"] = $"Producto {model.Code} - {model.Name} eliminado correctamente";
                return RedirectToAction("Index");
            } catch(ApiException ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                var product = _productRepo.FindByCode(code);
                return View(product);
            }
            
        }
    }
}