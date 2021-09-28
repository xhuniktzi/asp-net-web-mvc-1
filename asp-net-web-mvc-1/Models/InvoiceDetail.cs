using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_web_mvc_1.Models
{
    public class InvoiceDetail
    {
        public int Product_Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total
        {
            get { return Quantity * Price; }
        }
    }
}