using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Invoices.Exceptions;

namespace Invoices.Services;

public class ItemService : IItemService
{
    private readonly InvoiceDbContext _dbContext;
    private readonly IMapper mapper;
    public ItemService(InvoiceDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<List<ItemResponseDto>> GetAllItemsAsync()
    {
        var itemData = await this._dbContext.Item.ToListAsync();
        if(itemData.Count > 0)
        {
            return this.mapper.Map<List<ItemResponseDto>>(itemData);
        }
        throw new NoItemException(TextsException.NoItemExceptionText);
    }
}
