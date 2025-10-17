using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces
{
    public interface IFavoriteListRepository
    {
        Task<IEnumerable<FavoriteList>> GetListByClientAsync(string? clientId);
        Task<FavoriteList?> GetByIdAsync(string? id);
        Task<FavoriteList> CreateAsync(FavoriteList client);
        Task<FavoriteList> UpdateAsync(FavoriteList client);
        Task<bool> DeleteAsync(string? id);
    }
}
