using Invoices.Dtos;

namespace Invoices.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceResponseDto>> GetAllInvoices();
        Task<InvoiceResponseDto> GetInvoiceById(string id);
        Task<InvoiceResponseDto> CreateInvoice(CreateInvoiceDto newClient);
    }
}
