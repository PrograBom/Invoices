using Invoices.Dtos;

namespace Invoices.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetAllInvoices();
        Task<InvoiceDto> GetInvoiceById(int id);

    }
}
