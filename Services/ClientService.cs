using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services
{
    public class ClientService : IClientService
    {
        private readonly InvoiceDbContext _dbContext;
        private readonly IMapper mapper;

        public ClientService(InvoiceDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this.mapper = mapper;
        }

    public async Task<List<ClientDto>> GetAll()
        {
            var clientData = await this._dbContext.Client.ToListAsync();
            if(clientData != null && clientData.Count >= 0) {
                // automaper
                return this.mapper.Map<List<Client>, List<ClientDto>>(clientData);
            }
            return new List<ClientDto>();
        }
    }
}
