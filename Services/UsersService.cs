using AutoMapper;
using Invoices.Dtos;
using Invoices.Model;
using Invoices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Services;

public class UsersService : IUsersService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper mapper;

    public UsersService(ApplicationDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<User> SaveUserAsync(RequestUserDto requestUser)
    {
        var dbUser = new User();

        if(requestUser.Id == 0)
        {
            requestUser.ApplyChanges(dbUser);
            _dbContext.Users.Add(dbUser);
        } else
        {
            dbUser = _dbContext.Users.FirstOrDefault(u => u.Id == requestUser.Id);
            requestUser.ApplyChanges(dbUser);
        }
        _dbContext.SaveChanges();

        return dbUser;
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
            return this.mapper.Map<ClientDetail, ClientDto>(customerData);
        }
        return new ClientDto();
    }

}
