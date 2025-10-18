using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public class Client : Entity
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Cpf { get; private set; }
        public string Cep { get; private set; }
        public string Address { get; private set; }
        public string AddressNumber { get; private set; } 
        public bool Active { get; private set; }
        public IList<FavoriteList> FavoriteLists { get; private set; }

        public Client(string name, string email, string phone, string cpf, string cep, string address, string addressNumber)
        {
            Validate(name, email, phone, cpf, cep, address, addressNumber);
            Name = name;
            Email = email;
            Cpf = cpf;
            Phone = phone;
            Cep = cep;
            Address = address;
            AddressNumber = addressNumber;
            Active = true;
            FavoriteLists = new List<FavoriteList>();
            FavoriteLists.Add(new FavoriteList("Lista de desejos"));
        }

        public void Update(string name, string email, string phone, string cpf, string cep, string address, string addressNumber)
        {
            Validate(name, email, phone, cpf, cep, address, addressNumber);
            Name = name;
            Email = email;
            Cpf = cpf;
            Phone = phone;
            Cep = cep;
            Address = address;
            AddressNumber = addressNumber;
        }

        private void Validate(string name, string email, string phone, string cpf, string cep, string address, string addressNumber)
        {
            if (cpf.Length != 11)
                throw new Exception("CPF deve conter 11 caracteres");
            if (!email.Contains("@"))
                throw new Exception("Email inválido");
            //if (favoriteList == null)
            //    throw new Exception("Lista de favoritos é obrigatória");
        }

    }
}
