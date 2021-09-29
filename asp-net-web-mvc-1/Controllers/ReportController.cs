using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
using System;
using System.Web.Mvc;

namespace asp_net_web_mvc_1.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportsRepo;

        public ReportController()
        {
            _reportsRepo = new ReportRepository();
        }
        // GET: Report
        public ActionResult Index()
        {
            var model = new Report();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Report report)
        {
            if (DateTime.ParseExact(report.Start_Date, "yyyy-MM-dd",null) >
                DateTime.ParseExact(report.End_Date, "yyyy-MM-dd", null))
            {
                TempData["Error"] = "Rango de fechas ingresado invalido";
                return View(report);
            }

            var req = new ReportQueryDto();
            req.Start_Date = report.Start_Date;
            req.End_Date = report.End_Date;
            req.Serial_Number = report.Serial_Number;
            req.Invoice_Number = report.Invoice_Number;
            req.Client_Id = report.Client_Id;
            req.Product_Id = report.Product_Id;
            req.Branch_Id = report.Branch_Id;

            report.results = _reportsRepo.Search(req);
            return View(report);
        }
    }
}