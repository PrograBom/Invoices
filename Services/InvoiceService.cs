using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

    public async Task<List<InvoiceResponseDto>> GetAllInvoices()
    {
        var invoiceData = await this._dbContext.Invoice.ToListAsync();


        if (invoiceData != null && invoiceData.Count >= 0)
        {
            // automaper
            return this.mapper.Map<List<Invoice>, List<InvoiceResponseDto>>(invoiceData);
        }
        return new List<InvoiceResponseDto>();
    }

    public async Task<InvoiceResponseDto> GetInvoiceById(string id)
    {
        var invoiceData = await this._dbContext.Invoice.FirstOrDefaultAsync(item => item.Id.Equals(id));
        if (invoiceData != null)
        {
            return this.mapper.Map<Invoice, InvoiceResponseDto>(invoiceData);
        }
        return new InvoiceResponseDto();
    }

    public async Task<InvoiceResponseDto> CreateInvoice(CreateInvoiceDto newClient)
    {
        try
        {
            var invoice = new Invoice
            {
                IssueDate = newClient.IssueDate,
                DeliveryDate = newClient.DeliveryDate,
                DueDate = newClient.DueDate,
                Client = newClient.Client,
                Items = newClient.Items
            };

            _dbContext.Invoice.Add(invoice);
            await _dbContext.SaveChangesAsync();

            return new InvoiceResponseDto
            {
                Id = invoice.Id,
                IssueDate = invoice.IssueDate,
                DeliveryDate = invoice.DeliveryDate,
                DueDate = invoice.DueDate,
                Client = invoice.Client,
                Items = invoice.Items
            };
        }
        catch (Exception)
        {
            return null;
        }
    }
}
