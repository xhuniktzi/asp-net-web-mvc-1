using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Repository;
using System.Web.Mvc;

namespace asp_net_web_mvc_1.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IBranchRepository _branchRepo;
        public InvoiceController()
        {
            _productRepo = new ProductRepository();
            _clientRepo = new ClientRepository();
            _branchRepo = new BranchRepository();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderProducts()
        {
            var model = _productRepo.GetAll();
            return PartialView("ProductList", model);
        }

        [ChildActionOnly]
        public ActionResult RenderClients()
        {
            var model = _clientRepo.GetAll();
            return PartialView("ClientList", model);
        }

        [ChildActionOnly]
        public ActionResult RenderBranches()
        {
            var model = _branchRepo.GetAll();
            return PartialView("BranchList", model);
        }
    }
}