using Invoices.Dtos;
using Invoices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<List<ClientDto>> GetAllClients()
        {
            return await this._userService.GetAllClients();
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> GetById(string id)
        {
            return await this._userService.GetById(id);
        }

        [HttpPost]
        public async void Post([FromBody] RequestUserDto newUser)
        {
            await this._userService.SaveUserAsync(newUser);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
