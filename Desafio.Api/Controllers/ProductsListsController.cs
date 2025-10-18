using Desafio.Application.DTOs;
using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsListsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsListsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{listId}")]
        public async Task<ActionResult> Get(string listId)
        {
            var products = await _productService.GetProductsByListAsync(listId);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductListDTO productListDto)
        {
            try
            {
                var product = await _productService.AddProductToList(productListDto.productId, productListDto.listId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ProductListDTO productListDTO)
        {
            try 
            {
                var result = await _productService.DeleteAsync(productListDTO.productId, productListDTO.listId);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
