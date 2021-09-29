using System.Collections.Generic;
namespace asp_net_web_mvc_1.Models
{
    public class InvoiceDto
    {
        public string Serial_Number { get; set; }
        public int Invoice_Number { get; set; }
        public int Client_Id { get; set; }
        public int Branch_Id { get; set; }
        public string Order_Date { get; set; }
        public List<InvoiceDetailDto> Product_Detail { get; set; } = new List<InvoiceDetailDto>();
    }
}