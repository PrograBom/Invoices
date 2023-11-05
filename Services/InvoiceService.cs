using Invoices.Dtos;
using Invoices.Model;
using Invoices.Services.Interfaces;

namespace Invoices.Services;

public class InvoiceService : IInvoiceService
{
    private readonly ApplicationDbContext _dbContext;

    public InvoiceService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<InvoiceDto>> GetAllInvoices()
    {
        return null;
        //var invoices =  await _dbContext.Invoices.ToListAsync;


        //if (invoiceData != null && invoiceData.Count >= 0)
        //{
        //    // automaper
        //    return this.mapper.Map<List<Client>, List<ClientDto>>(invoiceData);
        //}
        //return new List<InvoiceDto>();
    }

    Task<InvoiceDto> IInvoiceService.GetInvoiceById(int id)
    {
        throw new NotImplementedException();
    }
}
