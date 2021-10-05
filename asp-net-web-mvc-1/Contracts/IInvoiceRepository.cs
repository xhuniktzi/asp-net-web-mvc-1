using asp_net_web_mvc_1.Models;

namespace asp_net_web_mvc_1.Contracts
{
    interface IInvoiceRepository
    {
        InvoiceDto CreateInvoice(InvoiceDto invoice);
        Print GetAnInvoice(int id);
    }
}
