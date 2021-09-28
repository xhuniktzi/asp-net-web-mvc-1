using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
using asp_net_web_mvc_1.Repository;
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
            report.results = _reportsRepo.Search(report);
            return View(report);
        }
    }
}