using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace asp_net_web_mvc_1.Models
{
    public class Print
    {
        public string Serial_Number { get; set; }
        public int Invoice_Number { get; set; }
        public string Client_Name { get; set; }
        public string Client_Nit { get; set; }
        public string Client_Direction { get; set; }
        public string Branch_Name { get; set; }
        public string Branch_Direction { get; set; }
        public List<PrintDetail> Product_Detail { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }

        private string _orderDate;

        public string Order_Date
        {
            get { return _orderDate.Split('T')[0]; }
            set { _orderDate = value; }
        }
    }
}