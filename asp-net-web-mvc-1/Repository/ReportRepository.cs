using asp_net_web_mvc_1.Contracts;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class ReportRepository : IReportRepository
    {
        public IEnumerable<ReportDetail> Search(ReportQueryDto query)
        {
            var url = $"{Properties.Settings.Default.API}/invoices/getInvoice";
            var data = JsonConvert.SerializeObject(query);
            var res = ConnectDatabase.ExecPost(url, data, "application/json");
            return JsonConvert.DeserializeObject<IEnumerable<ReportDetail>>(res);
        }
    }
}