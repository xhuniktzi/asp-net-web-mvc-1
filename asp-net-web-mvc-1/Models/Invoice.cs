using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_web_mvc_1.Models
{
    public class Invoice
    {
        public string Order_Date { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string Serial_Number { get; set; } = null;
        public int? Invoice_Number { get; set; } = null;
        public int? Client_Id { get; set; } = null;
        public string ClientName { get; set; } = null;
        public string ClientNit { get; set; } = null;
        public int? Branch_Id { get; set; } = null;
        public string BranchName { get; set; } = null;
        public string BranchDirection { get; set; } = null;
        public IEnumerable<InvoiceDetail> details { get; set; } = new List<InvoiceDetail>();
    }
}