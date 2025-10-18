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

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new Exception("Produto não encontrado");
            return new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
                Price = product.Price
            };
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
                Price = product.Price
            });
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByListAsync(string listId)
        {
            var products = await _productRepository.GetProductsByListAsync(listId);
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
                Price = product.Price
            });
        }

        public async Task<bool> DeleteAsync(int productId, string listId)
        {
            return await _productRepository.DeleteAsync(productId, listId);
        }
    }
}
