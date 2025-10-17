using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByListAsync(string listId);
        Task<Product?> GetByIdAsync(int? id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int? id);
        Task<Product> AddProductToList(int productId, string listId);
        Task<bool> ProductExistsInListAsync(int productId, string listId);
    }
}
