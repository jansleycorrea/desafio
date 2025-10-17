using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Desafio.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _contextProduct;

        public ProductRepository(ApplicationDbContext contextProduct, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient"); ;
            _contextProduct = contextProduct;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(int? id)
        {
            var url = $"/products/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<Product>();
            if (product == null) return null;
            return product;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync(string listId)
        {
            var response = await _httpClient.GetAsync("/products");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();

            if (products == null) return Enumerable.Empty<Product>();
            return products.ToList();
        }
        public async Task<IEnumerable<Product>> GetProductsByListAsync(string listId)
        {
            var products = await _contextProduct.Product.Where(p => p.FavoriteListId.ToString() == listId).ToListAsync();
            return products;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProductExistsInListAsync(int productId, string listId)
        {
            var product = await _contextProduct.Product
                .Where(p => p.Id == productId && p.FavoriteListId.ToString() == listId).FirstAsync();
            return product != null;
        }

        public async Task<Product> AddProductToList(int productId, string listId)
        {
            var url = $"/products/{productId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<Product>();

            var productEntity = _contextProduct.Add(new Product
            (
                productId,
                product.Description,
                product.Title,
                product.Category,
                product.Image,
                Guid.Parse(listId)
            ));
            await _contextProduct.SaveChangesAsync();
            return productEntity.Entity;
        }
    }
}
