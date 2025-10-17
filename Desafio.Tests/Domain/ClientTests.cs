using Desafio.Domain.Entities;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Tests.Domain
{
    public class ClientTests
    {
        [Fact(DisplayName = "Teste de cadastro")]
        public void CreateClient_ValidData_ShouldCreateClient()
        {
            // Arrange
            var name = "John Doe";
            var email = "jansley@email.com";
            var phone = "1234567890";
            var address = "123 Main";
            var cpf = "12345678901";
            var cep = "12345678";
            var addressNumber = "100";
            var client = new Client(name, email, phone, cpf, cep, address, addressNumber);
            Assert.IsType<Client>(client);
        }

        [Fact(DisplayName = "Teste de cadastro com lista de favoritos nula")]
        public void CreateClient_FavoriteListIsNull_ShouldThrowException()
        {
            // Arrange
            var name = "John Doe";
            var email = "jansley@email.com";
            var phone = "1234567890";
            var address = "123 Main";
            var cpf = "12345678901";
            var cep = "12345678";
            var addressNumber = "100";
            Assert.Throws<Exception>(() => 
                new Client(name, email, phone, cpf, cep, address, addressNumber)
            );
        }
    }
}
