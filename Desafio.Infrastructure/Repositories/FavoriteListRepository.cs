using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Infrastructure.Repositories
{
    public class FavoriteListRepository : IFavoriteListRepository
    {
        private ApplicationDbContext _favoriteListContext;
        public FavoriteListRepository(ApplicationDbContext context)
        {
            _favoriteListContext = context;
        }
        public async Task<FavoriteList> CreateAsync(FavoriteList client)
        {
            var newFavoriteList = _favoriteListContext.Add(client);
            await _favoriteListContext.SaveChangesAsync();
            return newFavoriteList.Entity;

        }

        public async Task<bool> DeleteAsync(string? id)
        {
            var favoriteList = await _favoriteListContext.FavoriteList.FindAsync(id);
            if (favoriteList == null) return false;
            _favoriteListContext.Remove(favoriteList);
            return await _favoriteListContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<FavoriteList>> GetListByClientAsync(string? clientId)
        {
            if (clientId == null)
                return new List<FavoriteList>();
            return await _favoriteListContext.FavoriteList.Include(f => f.Products).Where(f => f.ClientId == Guid.Parse(clientId)).ToListAsync();
        }

        public async Task<FavoriteList?> GetByIdAsync(string? id)
        {
            return await _favoriteListContext.FavoriteList.FindAsync(id);
        }

        public async Task<FavoriteList> UpdateAsync(FavoriteList client)
        {
            var updateFavoriteList = _favoriteListContext.Update(client);
            await _favoriteListContext.SaveChangesAsync();
            return updateFavoriteList.Entity;
        }
    }
}
