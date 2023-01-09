using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services;

public class InvoiceService : IInvoiceService
{
    private readonly InvoiceDbContext _dbContext;

    public InvoiceService(InvoiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<InvoiceDto>> IInvoiceService.GetAllInvoices()
    {
        var invoiceData = await this._dbContext.Invoice.ToListAsync;


        if (invoiceData != null && invoiceData.Count >= 0)
        {
            // automaper
            return this.mapper.Map<List<Client>, List<ClientDto>>(invoiceData);
        }
        return new List<InvoiceDto>();
    }

    Task<InvoiceDto> IInvoiceService.GetInvoiceById(int id)
    {
        throw new NotImplementedException();
    }
}
