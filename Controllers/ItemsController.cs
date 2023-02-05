using Invoices.Dtos;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        this._itemService = itemService;
    }

    [HttpGet]
    public async Task<List<ItemResponseDto>> GetAllItemsAsync()
    {
        return await this._itemService.GetAllItemsAsync();
    }
}
