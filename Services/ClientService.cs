using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services
{
    public class ClientService : IClientService
    {
        private readonly InvoiceDbContext _dbContext;
        public ClientService(InvoiceDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

    public async Task<List<Client>> GetAll()
        {
            return await this._dbContext.Client.ToListAsync();
        }
    }
}
