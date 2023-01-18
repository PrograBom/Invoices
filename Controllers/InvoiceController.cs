using Invoices.Dtos;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<List<InvoiceResponseDto>> GetAllInvoices()
        {
            return await this._invoiceService.GetAllInvoices();
        }

        [HttpGet("{id}")]
        public async Task<InvoiceResponseDto> GetInvoiceById(string id)
        {
            return await this._invoiceService.GetInvoiceById(id);
        }

        [HttpPost]
        public async Task<InvoiceResponseDto> CreateInvoice([FromBody] CreateInvoiceDto newClient)
        {
            return await this._invoiceService.CreateInvoice(newClient);
        }
    }
}