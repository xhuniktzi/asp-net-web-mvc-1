namespace asp_net_web_mvc_1.Models
{
    public class InvoiceDetail
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public double Total
        {
            get { return Quantity * product.Price; }
        }
    }
}