using Invoices.Dtos;
using Invoices.Model;
using Invoices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            return await this._clientService.GetAllClients();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ClientDto> GetClientByIdAsync(string id)
        {
            return await this._clientService.GetClientById(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> CreateClientAsync([FromBody] ClientCreateDto newClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this._clientService.CreateClient(newClient);
            return null;
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void ChangeClient(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
