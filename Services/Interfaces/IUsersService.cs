using Invoices.Dtos;
using Invoices.Model;

namespace Invoices.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ClientDto> GetById(string id);
        Task<User> SaveUserAsync(RequestUserDto newClient);
        Task<List<ClientDto>> GetAllClients();
    }
}
