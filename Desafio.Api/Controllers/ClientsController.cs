using Desafio.Application.DTOs;
using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var clients = await _clientService.GetClientsAsync(0, 15);
            if (clients == null) return NoContent();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> Get(string id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null) return NoContent();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> Post([FromBody] ClientDTO clientDto)
        {
            try
            {
                var client = await _clientService.CreateAsync(clientDto);
                if (client == null) return BadRequest("Falha ao cadastrar o usuário");
                return Ok(client);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
