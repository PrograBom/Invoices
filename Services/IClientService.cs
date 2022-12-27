using Invoices.Dtos;

namespace Invoices.Services
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAll();
    }
}
