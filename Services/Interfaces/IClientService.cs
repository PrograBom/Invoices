using Invoices.Dtos;

namespace Invoices.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDto> GetById(string id);
        Task<ResponseType> CreateClient(ClientCreateDto newClient);
        Task<ResponseType> UpdateClient();
        Task<List<ClientDto>> GetAllClients();
    }
}
