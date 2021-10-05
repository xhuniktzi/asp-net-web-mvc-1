using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Repository;
using SelectPdf;
using System.IO;
using System.Web.Mvc;

namespace asp_net_web_mvc_1.Controllers
{
    public class PrintController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepo;

        public PrintController()
        {
            _invoiceRepo = new InvoiceRepository();
        }
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult PrintInvoice(int id)
        //{
        //    //View().ToString();
        //    return Content($"ID: {id}");
        //}

        public ActionResult GetInvoice(int id)
        {
            var model = _invoiceRepo.GetAnInvoice(id);
            // read parameters from the webpage
            //string url = $"/Print/PrintInvoice/{id}";
            string html = RenderViewToString(ControllerContext, "~/Views/Print/Invoice.cshtml", model, true);

            //string pdf_page_size = Collection["DdlPageSize"];
            PdfPageSize pageSize = PdfPageSize.A4;
                //(PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdf_page_size, true);

            //string pdf_orientation = collection["DdlPageOrientation"];
            PdfPageOrientation pdfOrientation = PdfPageOrientation.Portrait;
            //(PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
            //pdf_orientation, true);


            int webPageWidth = 1024;
            //try
            //{
            //    webPageWidth = System.Convert.ToInt32(collection["TxtWidth"]);
            //}
            //catch { }

            int webPageHeight = 0;
            //try
            //{
            //    webPageHeight = System.Convert.ToInt32(collection["TxtHeight"]);
            //}
            //catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();
            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;
            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(html);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

        }

        static string RenderViewToString(ControllerContext context, string viewPath, object model = null, bool partial = false)
        {
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, viewPath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, viewPath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}