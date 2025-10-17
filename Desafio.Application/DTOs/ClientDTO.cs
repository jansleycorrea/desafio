using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.DTOs
{
    public class ClientDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage="O campo nome é obrigatório")]
        [MaxLength(256, ErrorMessage="O campo nome deve ter no máximo 256 caracteres")]
        [MinLength(3, ErrorMessage="O campo nome deve ter no mínimo 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [MaxLength(256, ErrorMessage = "O campo e-mail deve ter no máximo 256 caracteres")]
        [EmailAddress(ErrorMessage = "O campo e-mail ser um e-mail válido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O campo deve ser um telefone válido")]
        [MaxLength(20, ErrorMessage = "O campo telefone deve ter no máximo 20 caracteres")]
        [MinLength(8, ErrorMessage = "O campo telefone deve ter no mínimo 8 caracteres")]
        public string Phone { get; set; }

        [MaxLength(11, ErrorMessage = "O campo CPF deve ter no máximo 11 caracteres")]
        [MinLength(11, ErrorMessage = "O campo CPF deve ter no mínimo 11 caracteres")]
        public string Cpf { get; set; }

        [MaxLength(8, ErrorMessage = "O campo CEP deve ter no máximo 8 caracteres")]
        [MinLength(8, ErrorMessage = "O campo CEP deve ter no mínimo 8 caracteres")]
        public string Cep { get; set; }

        [MaxLength(256, ErrorMessage = "O campo endereço deve ter no máximo 256 caracteres")]
        public string Address { get; set; }

        [MaxLength(10, ErrorMessage = "O campo número do endereço deve ter no máximo 10 caracteres")]
        public string AddressNumber { get; set; }
        public ClientDTO()
        {

        }
        public ClientDTO(string name, string email, string phone, string cpf, string cep, string address, string addressNumber)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Cpf = cpf;
            Cep = cep;
            Address = address;
            AddressNumber = addressNumber;
        }

        public ClientDTO(string id, string name, string email, string phone, string cpf, string cep, string address, string addressNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Cpf = cpf;
            Cep = cep;
            Address = address;
            AddressNumber = addressNumber;
        }
    }
}
