using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper mapper;

    public ClientService(ApplicationDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ResponseType> CreateClient(ClientCreateDto newClient)
    {
        string result = string.Empty;
        if(newClient != null)
        {
            
            var _client = this._dbContext.ClientDetails.FirstOrDefault(item => item.Id == newClient.ClientId);
            if (_client != null)
            {
                // Klient s daným ID už existuje, môžete spracovať chybu alebo vyvolať výnimku.
                return new ResponseType() { KyValue = string.Empty, Result = "Client with the same ID already exists." };
            }
            else
            {
                var newUserClient = new User()
                {
                    Id = newClient.ClientId,
                    Name = newClient.Name,
                    BankNumber = newClient.BankNumber,
                };

                // Vytvorte novú inštanciu ClientDetails
                var newClientDetails = new ClientDetails()
                {
                    Id = Guid.NewGuid().ToString(), // Priraďte nové ID pre ClientDetails (ak je potrebné)
                    TaxId = newClient.TaxId,
                    VatId = newClient.VatId,
                    UserId = newUserClient.Id, // Nastavte cizí kľúč na UserId
                };

                newUserClient.ClientDetails = newClientDetails; // Nastavte navigačnú vlastnosť

                await this._dbContext.Users.AddAsync(newUserClient);
                this._dbContext.SaveChanges();
                return new ResponseType() { KyValue = newUserClient.Name, Result = "saved" };
            }
        }
        return new ResponseType() { KyValue = string.Empty, Result = "fail" };
    }

    public async Task<List<ClientDto>> GetAllClients()
    {
        var clientData = await this._dbContext.Users.ToListAsync();
        if(clientData != null && clientData.Count >= 0) {
            // automaper
            return this.mapper.Map<List<User>, List<ClientDto>>(clientData);
        }
        return new List<ClientDto>();
    }

    public async Task<ClientDto> GetById(string id)
    {
        var customerData = await this._dbContext.ClientDetails.FirstOrDefaultAsync(item => item.Id.Equals(id));
        if(customerData != null)
        {
            return this.mapper.Map<ClientDetails, ClientDto>(customerData);
        }
        return new ClientDto();
    }

    public Task<ResponseType> UpdateClient()
    {
        throw new NotImplementedException();
    }

}
