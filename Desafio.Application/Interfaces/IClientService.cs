using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Application.DTOs;

namespace Desafio.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClientsAsync(int take, int skip);
        Task<ClientDTO?> GetByIdAsync(string? id);
        Task<ClientDTO> CreateAsync(ClientDTO client);
        Task<ClientDTO> UpdateAsync(ClientDTO client);
        Task<bool> DeleteAsync(string? id);
    }
}
