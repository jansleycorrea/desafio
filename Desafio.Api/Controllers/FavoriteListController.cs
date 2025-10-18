using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteListController : ControllerBase
    {
        private readonly IFavoriteListService _favoriteListService;

        public FavoriteListController(IFavoriteListService favoriteListService)
        {
            _favoriteListService = favoriteListService;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult> Get(string clientId)
        {
            var favoriteList = await _favoriteListService.GetListByClientAsync(clientId);
            return Ok(favoriteList);
        }
    }
}
