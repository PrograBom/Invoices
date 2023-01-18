using Invoices.Dtos;

namespace Invoices.Services
{
    public interface IClientService
    {
        Task<ClientDto> GetClientById(string id);
        Task<ResponseType> CreateClient(ClientCreateDto newClient);
        Task<ResponseType> UpdateClient();
        Task<List<ClientDto>> GetAllClients();
    }
}
