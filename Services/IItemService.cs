using Invoices.Dtos;

namespace Invoices.Services
{
    public interface IItemService
    {
        Task<List<ItemResponseDto>> GetAllItemsAsync();
    }
}
