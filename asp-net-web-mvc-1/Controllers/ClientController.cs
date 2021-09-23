using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.ErrorHandling;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
using System.Linq;
using System.Web.Mvc;

namespace asp_net_web_mvc_1.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepo;
        public ClientController()
        {
            _clientRepo = new ClientRepository();
        }
        // GET: Client
        public ActionResult Index(string NameSortOrder)
        {
            if (string.IsNullOrEmpty(NameSortOrder))
            {
                ViewBag.NameSortParam = "asc";
                var model = _clientRepo.GetAll();
                return View(model);
            }
            else if (NameSortOrder == "asc")
            {
                ViewBag.NameSortParam = "desc";
                var model = from client in _clientRepo.GetAll()
                            orderby client.Name ascending
                            select client;
                return View(model);
            }
            else if (NameSortOrder == "desc")
            {
                ViewBag.NameSortParam = "asc";
                var model = from client in _clientRepo.GetAll()
                            orderby client.Name descending
                            select client;
                return View(model);
            }
            else
            {
                var model = _clientRepo.GetAll();
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            var model = _clientRepo.FindById(id);
            if (model == null)
            {
                TempData["Error"] = "El cliente no existe";
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
        public ActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdClient = _clientRepo.CreateClient(client);
                    TempData["Success"] = $"Cliente: {client.Name} creado correctamente";
                    return RedirectToAction("Details", new { id = createdClient.Client_Id});
                }
                return View();
            }
            catch (ApiException ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
                return View(client);
            }

        }
    }
}