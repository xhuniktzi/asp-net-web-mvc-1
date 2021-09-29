using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total
        {
            get { return Quantity * Price; }
        }
    }
}