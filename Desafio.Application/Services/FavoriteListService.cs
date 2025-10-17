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
    public class FavoriteListService : IFavoriteListService
    {
        private readonly IFavoriteListRepository _favoriteListRepository;

        public FavoriteListService(IFavoriteListRepository favoriteListRespository)
        {
            _favoriteListRepository = favoriteListRespository;
        }
        public Task<FavoriteListDTO> CreateAsync(FavoriteListDTO favoriteList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string? id)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteListDTO?> GetByIdAsync(string? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FavoriteListDTO>> GetListByClientAsync(string? clientId)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteListDTO> UpdateAsync(FavoriteListDTO favoriteList)
        {
            throw new NotImplementedException();
        }
    }
}
