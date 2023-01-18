using Invoices.Dtos;

namespace Invoices.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetAllInvoices();
        Task<InvoiceDto> GetInvoiceById(string id);

    }
}
