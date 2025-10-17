using Desafio.Application.DTOs;
using Desafio.Application.Interfaces;
using Desafio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> AddProductToList(int productId, string favoriteList)
        {
            if (await _productRepository.ProductExistsInListAsync(productId, favoriteList))
                throw new Exception("Produto já existe na lista de favoritos");
            var product = await _productRepository.AddProductToList(productId, favoriteList);
            return new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image
            };
        }

        public Task<ProductDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProductsByListAsync(string listId)
        {
            throw new NotImplementedException();
        }
    }
}
