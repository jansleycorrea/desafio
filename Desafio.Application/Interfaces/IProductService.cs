using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Application.DTOs;

namespace Desafio.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> AddProductToList(int productId, string favoriteList);
        Task<IEnumerable<ProductDTO>> GetProductsByListAsync(string listId);
    }
}
