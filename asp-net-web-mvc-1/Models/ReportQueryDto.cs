using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_net_web_mvc_1.Models
{
    public class ReportQueryDto
    {
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Serial_Number { get; set; } = null;
        public int? Invoice_Number { get; set; } = null;
        public int? Client_Id { get; set; } = null;
        public int? Product_Id { get; set; } = null;
        public int? Branch_Id { get; set; } = null;
    }
}