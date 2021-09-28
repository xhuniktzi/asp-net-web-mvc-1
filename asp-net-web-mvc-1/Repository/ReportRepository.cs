using asp_net_web_mvc_1.Contracts;
using System.Collections.Generic;
using asp_net_web_mvc_1.Models;
using Newtonsoft.Json;

namespace asp_net_web_mvc_1.Repository
{
    public class ReportRepository : IReportRepository
    {
        public IEnumerable<ReportDetail> Search(Report query)
        {
            var url = $"{Properties.Settings.Default.API}/invoices/getInvoice";
            var req = new ReportQueryDto();
            req.Start_Date = query.Start_Date;
            req.End_Date = query.End_Date;
            req.Serial_Number = query.Serial_Number;
            req.Invoice_Number = query.Invoice_Number;
            req.Client_Id = query.Client_Id;
            req.Product_Id = query.Product_Id;
            req.Branch_Id = query.Branch_Id;

            var data = JsonConvert.SerializeObject(req);
            var res = ConnectDatabase.ExecPost(url, data, "application/json");
            return JsonConvert.DeserializeObject<IEnumerable<ReportDetail>>(res);
        }
    }
}