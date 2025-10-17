using Desafio.Application.DTOs;
using Desafio.Application.Interfaces;
using Desafio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain.Entities;

namespace Desafio.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ClientDTO> CreateAsync(ClientDTO client)
        {
            var clientEntity = new Client(
                client.Name,
                client.Email,
                client.Phone,
                client.Cpf,
                client.Cep,
                client.Address,
                client.AddressNumber
            );
            if (await _clientRepository.EmailExists(client.Email))
                throw new Exception("Email já cadastrado");
            clientEntity = await _clientRepository.CreateAsync(clientEntity);

            return new ClientDTO
            {
                Id = clientEntity.Id.ToString(),
                Name = clientEntity.Name,
                Email = clientEntity.Email,
                Phone = clientEntity.Phone,
                Cpf = clientEntity.Cpf,
                Cep = clientEntity.Cep,
                Address = clientEntity.Address,
                AddressNumber = clientEntity.AddressNumber
            };
        }

        public async Task<bool> DeleteAsync(string? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientDTO>> GetClientsAsync(int take, int skip)
        {
            var clients = await _clientRepository.GetClientsAsync(take, skip);
            return clients.Select(c => new ClientDTO
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            });
        }

        public async Task<ClientDTO?> GetByIdAsync(string? id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) return null;
            return new ClientDTO
            {
                Id = client.Id.ToString(),
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };
        }

        public async Task<ClientDTO> UpdateAsync(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
