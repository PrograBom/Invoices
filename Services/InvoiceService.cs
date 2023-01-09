using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services;

public class InvoiceService : IInvoiceService
{
    private readonly InvoiceDbContext _dbContext;
    private readonly IMapper mapper;

    public InvoiceService(InvoiceDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<List<InvoiceDto>> GetAllInvoices()
    {
        var invoiceData = await this._dbContext.Invoice.ToListAsync();


        if (invoiceData != null && invoiceData.Count >= 0)
        {
            // automaper
            return this.mapper.Map<List<Invoice>, List<InvoiceDto>>(invoiceData);
        }
        return new List<InvoiceDto>();
    }

    Task<InvoiceDto> IInvoiceService.GetInvoiceById(int id)
    {
        throw new NotImplementedException();
    }
}
