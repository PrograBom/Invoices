using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services;

public class ClientService : IClientService
{
    private readonly InvoiceDbContext _dbContext;
    private readonly IMapper mapper;

    public ClientService(InvoiceDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ResponseType> CreateClient(ClientCreateDto newClient)
    {
        string result = string.Empty;
        if(newClient != null)
        {
            
            var _client = this._dbContext.Client.FirstOrDefault(item => item.ClientId == newClient.ClientId);
            if (_client != null)
            {
                //throw an axception
                throw new InvalidOperationException();
            }
            else
            {
                var _newClient = new Client()
                {
                    ClientId = newClient.ClientId,
                    BankNumber= newClient.BankNumber,
                    City= newClient.City,
                    Name= newClient.Name,
                    PostalCode= newClient.PostalCode,
                    Street= newClient.Street,
                    TaxId= newClient.TaxId,
                    VatId= newClient.VatId
                }as Client;
                await this._dbContext.Client.AddAsync(_newClient);
                this._dbContext.SaveChanges();
                return new ResponseType() { KyValue = _newClient.Name, Result = "saved" };
            }
        }
        return new ResponseType() { KyValue = string.Empty, Result = "fail" };
    }

    public async Task<List<ClientDto>> GetAllClients()
    {
        var clientData = await this._dbContext.Client.ToListAsync();
        if(clientData.Count >= 0) {
            // automaper
            return this.mapper.Map<List<Client>, List<ClientDto>>(clientData);
        }
        return new List<ClientDto>();
    }

    public async Task<ClientDto> GetClientById(string id)
    {
        var customerData = await this._dbContext.Client.FirstOrDefaultAsync(item => item.ClientId.Equals(id));
        if(customerData != null)
        {
            return this.mapper.Map<Client, ClientDto>(customerData);
        }
        return new ClientDto();
    }

    public Task<ResponseType> UpdateClient()
    {
        throw new NotImplementedException();
    }

}
