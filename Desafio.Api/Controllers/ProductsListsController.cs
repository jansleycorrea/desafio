using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsListsController : ControllerBase
    {
        [HttpGet("{listId}")]
        public async Task<ActionResult> Get(string listId)
        {
            return Ok("ProductsListsController is working!");
        }
    }
}
