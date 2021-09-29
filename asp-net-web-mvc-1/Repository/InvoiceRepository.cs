using asp_net_web_mvc_1.Contracts;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public InvoiceDto CreateInvoice(InvoiceDto invoice)
        {
            var url = $"{Properties.Settings.Default.API}/invoices";
            var data = JsonConvert.SerializeObject(invoice);
            var res = ConnectDatabase.ExecPost(url, data, "application/json");
            return JsonConvert.DeserializeObject<InvoiceDto>(res);
        }
    }
}