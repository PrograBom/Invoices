using Invoices.Dtos;
using Invoices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<List<ClientDto>> GetAllClients()
        {
            return await this._clientService.GetAllClients();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ClientDto> GetById(string id)
        {
            return await this._clientService.GetById(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async void Post([FromBody] ClientCreateDto newClient)
        {
            await this._clientService.CreateClient(newClient);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
