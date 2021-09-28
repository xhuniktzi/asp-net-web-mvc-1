using System;
using System.Collections.Generic;

namespace asp_net_web_mvc_1.Models
{
    public class Invoice
    {
        public Client client { get; set; }
        public Branch branch { get; set; }
        public String Serial_Number { get; set; }
        public int Invoice_Number { get; set; }
        public string Order_Date { get; set; }
        public IEnumerable<InvoiceDetail> Product_Detail { get; set; }
    }
}