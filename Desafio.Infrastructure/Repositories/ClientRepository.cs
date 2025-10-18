using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _clientContext;
        public ClientRepository(ApplicationDbContext context)
        {
            _clientContext = context;
        }
        public async Task<Client> CreateAsync(Client client)
        {
            var newClient = _clientContext.Add(client);
            await _clientContext.SaveChangesAsync();
            return newClient.Entity;
        }

        public async Task<bool> DeleteAsync(string? id)
        {
            var client = await _clientContext.Client.FindAsync(Guid.Parse(id));
            if (client == null) return false;
            _clientContext.Remove(client);
            return await _clientContext.SaveChangesAsync() > 0;
        }

        public async Task<Client?> GetByIdAsync(string? id)
        {
            return await _clientContext.Client.FindAsync(Guid.Parse(id));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(int skip = 0, int take = 25)
        {
            var clients = await _clientContext.Client
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return clients;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            var updateClient = _clientContext.Update(client);
            await _clientContext.SaveChangesAsync();
            return updateClient.Entity;
        }
        public async Task<bool> EmailExists(string email)
        {
            var client = await _clientContext.Client.Where(c => c.Email == email).FirstOrDefaultAsync();
            return client != null;
        }
    }
}
