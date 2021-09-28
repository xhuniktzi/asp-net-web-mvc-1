using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_net_web_mvc_1.Models
{
    public class Report
    {
       
        public string Start_Date { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string End_Date { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string Serial_Number { get; set; } = null;
        public int? Invoice_Number { get; set; } = null;
        public int? Client_Id { get; set; } = null;
        public int? Product_Id { get; set; } = null;
        public int? Branch_Id { get; set; } = null;
        public IEnumerable<ReportDetail> results { get; set; } = new List<ReportDetail>();
    }
}