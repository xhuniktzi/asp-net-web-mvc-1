using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_net_web_mvc_1.Models
{
    public class ReportDetail
    {

        public int Order_Id { get; set; }
        public string Serial_Number { get; set; }
        public int Invoice_Number { get; set; }
        public string Client_Name { get; set; }
        public string Client_Direction { get; set; }
        public string Client_Nit { get; set; }
        public int Branch_Id { get; set; }
        public string Branch_Name { get; set; }
        public string Branch_Direction { get; set; }
        public String Order_Date { get; set; }
        public int Product_Id { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Order_Total { get; set; }
    }
}