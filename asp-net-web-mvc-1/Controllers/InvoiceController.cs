using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
using asp_net_web_mvc_1.Extensions;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace asp_net_web_mvc_1.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IClientRepository _clientRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IProductRepository _productRepo;
        public InvoiceController()
        {
            _clientRepo = new ClientRepository();
            _branchRepo = new BranchRepository();
            _productRepo = new ProductRepository();
        }
        // GET: Invoice
        public ActionResult Index(int? clientId, int? branchId, string productCode, int? quantity)
        {
            var model = new Invoice();
            if(clientId != null)
            {
                var client = _clientRepo.FindById(clientId.GetValueOrDefault());
                model.Client_Id = client.Client_Id;
                model.ClientName = client.Name;
                model.ClientNit = client.Nit;
                Session["CLIENT"] = client;
            }
            else if (Session["CLIENT"] != null)
            {
                var client = Session["CLIENT"] as Client;
                model.Client_Id = client.Client_Id;
                model.ClientName = client.Name;
                model.ClientNit = client.Nit;
            }

            if (branchId != null)
            {
                var branch = _branchRepo.FindById(branchId.GetValueOrDefault());
                model.Branch_Id = branch.Branch_Id;
                model.BranchName = branch.Name;
                model.BranchDirection = branch.Direction;
                Session["BRANCH"] = branch;
            }
            else if (Session["BRANCH"] != null)
            {
                var branch = Session["BRANCH"] as Branch;
                model.Branch_Id = branch.Branch_Id;
                model.BranchName = branch.Name;
                model.BranchDirection = branch.Direction;
            }

            if(!productCode.IsNullOrEmptyOrWhiteSpace() && quantity != null)
            {
                if (!(quantity > 0))
                {
                    TempData["Error"] = "Debe ingresar una cantidad mayor a 0";
                    model.details = Session["PRODUCTS"] as List<InvoiceDetail>;
                    return View(model);
                }

                if (Session["PRODUCTS"] == null)
                {
                    var detail = new InvoiceDetail();
                    var product = _productRepo.FindByCode(productCode);
                    detail.Product_Id = product.Product_Id;
                    detail.Code = product.Code;
                    detail.Name = product.Name;
                    detail.Price = product.Price;
                    detail.Quantity = quantity.GetValueOrDefault();

                    var productList = new List<InvoiceDetail>();
                    productList.Add(detail);

                    Session["PRODUCTS"] = productList;
                    model.details = productList;
                }
                else
                {
                    var detail = new InvoiceDetail();
                    var product = _productRepo.FindByCode(productCode);
                    detail.Product_Id = product.Product_Id;
                    detail.Code = product.Code;
                    detail.Name = product.Name;
                    detail.Price = product.Price;
                    detail.Quantity = quantity.GetValueOrDefault();

                    var productList = Session["PRODUCTS"] as List<InvoiceDetail>;

                    var duplicates = from p in productList
                                     where p.Product_Id == product.Product_Id
                                     select p;

                    if(duplicates.Count() > 0)
                    {
                        TempData["Error"] = "No puedes ingresar un producto 2 veces";
                        model.details = productList;
                        return View(model);
                    }

                    productList.Add(detail);

                    Session["PRODUCTS"] = productList;
                    model.details = productList;
                }
            }
            else if (Session["PRODUCTS"] != null)
            {
                var productList = Session["PRODUCTS"] as List<InvoiceDetail>;
                model.details = productList;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(Invoice invoice,FormCollection form)
        {
            Session["CLIENT"] = null;
            Session["BRANCH"] = null;
            Session["PRODUCTS"] = null;
            return RedirectToAction("Index");
        }
    }
}