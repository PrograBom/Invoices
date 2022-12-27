using Invoices.Model;

namespace Invoices.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
    }
}
