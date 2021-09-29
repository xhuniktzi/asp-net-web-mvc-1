using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
using asp_net_web_mvc_1.Extensions;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using asp_net_web_mvc_1.ErrorHandling;

namespace asp_net_web_mvc_1.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IClientRepository _clientRepo;
        private readonly IBranchRepository _branchRepo;
        private readonly IProductRepository _productRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        public InvoiceController()
        {
            _clientRepo = new ClientRepository();
            _branchRepo = new BranchRepository();
            _productRepo = new ProductRepository();
            _invoiceRepo = new InvoiceRepository();
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

            if (!productCode.IsNullOrEmptyOrWhiteSpace() && quantity == null)
            {
                if (Session["PRODUCTS"] != null)
                {
                    TempData["Error"] = "Debe ingresar una cantidad";
                    model.details = Session["PRODUCTS"] as List<InvoiceDetail>;
                    return View(model);
                }
                else
                {
                    TempData["Error"] = "Debe ingresar una cantidad";
                    return View(model);
                }
            }
            else if(!productCode.IsNullOrEmptyOrWhiteSpace() && quantity != null)
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

        public ActionResult Delete(int id)
        {
            var productList = Session["PRODUCTS"] as List<InvoiceDetail>;
            productList.RemoveAll(p => p.Product_Id == id);
            Session["PRODUCTS"] = productList;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(Invoice invoice, FormCollection form)
        {
            try
            {
                if (Session["PRODUCTS"] == null)
                {
                    TempData["Error"] = "Debes tener algun producto";
                    return View(invoice);
                }
                var productList = Session["PRODUCTS"] as List<InvoiceDetail>;
                invoice.details = productList;

                if (!(productList.Count() > 0))
                {
                    TempData["Error"] = "Debes tener algun producto";
                    return View(invoice);
                }

                if (Session["CLIENT"] == null)
                {
                    TempData["Error"] = "Debes seleccionar un cliente";
                    return View(invoice);
                }

                if (Session["BRANCH"] == null)
                {
                    TempData["Error"] = "Debes seleccionar una sucursal";
                    return View(invoice);
                }

                var client = Session["CLIENT"] as Client;
                var branch = Session["BRANCH"] as Branch;

                if (invoice.Serial_Number.IsNullOrEmptyOrWhiteSpace())
                {
                    TempData["Error"] = "Debes ingresar una serie para la factura";
                    return View(invoice);
                }

                if (invoice.Invoice_Number == null)
                {
                    TempData["Error"] = "Debes ingresar numero de factura";
                    return View(invoice);
                }

                var info = new InvoiceDto();
                info.Client_Id = client.Client_Id;
                info.Branch_Id = branch.Branch_Id;
                info.Serial_Number = invoice.Serial_Number;
                info.Invoice_Number = invoice.Invoice_Number.GetValueOrDefault();
                info.Order_Date = invoice.Order_Date;

                foreach (var product in productList)
                {
                    info.Product_Detail.Add(new InvoiceDetailDto()
                    {
                        Product_Id = product.Product_Id,
                        Quantity = product.Quantity
                    });
                }

                _invoiceRepo.CreateInvoice(info);


                Session["PRODUCTS"] = null;
                Session["CLIENT"] = null;
                Session["BRANCH"] = null;

                Session.Clear();

                return RedirectToAction("Index");
            }
            catch (ApiException ex)
            {
                if (Session["PRODUCTS"] != null)
                    invoice.details = Session["PRODUCTS"] as List<InvoiceDetail>;
                TempData["Error"] = $"Error: {ex.Message}";
                return View(invoice);
            }

        }
    }
}