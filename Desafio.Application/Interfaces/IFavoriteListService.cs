using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Application.DTOs;

namespace Desafio.Application.Interfaces
{
    public interface IFavoriteListService
    {
        Task<IEnumerable<FavoriteListDTO>> GetListByClientAsync(string? clientId);
        Task<FavoriteListDTO?> GetByIdAsync(string? id);
        Task<FavoriteListDTO> CreateAsync(FavoriteListDTO favoriteList);
        Task<FavoriteListDTO> UpdateAsync(FavoriteListDTO favoriteList);
        Task<bool> DeleteAsync(string? id);
    }
}
