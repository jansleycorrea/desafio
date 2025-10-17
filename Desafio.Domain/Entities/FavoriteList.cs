using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public class FavoriteList : Entity
    {
        public string Name { get; private set; }
        public bool Default { get; private set; }
        public IList<Product> Products { get; private set; }
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
        public FavoriteList(string name)
        {
            Validate(name);
            Name = name;
            Default = true;
            Products = new List<Product>();
        }
        public FavoriteList(string name, Client client, bool def)
        {
            Validate(name);
            Name = name;
            Client = client;
            Default = def;
            Products = new List<Product>();
        }

        public void Validate(string name)
        {
            if (name == null || name.Length == 0)
                throw new Exception("Nome da lista de favoritos é obrigatório");
        }

        public void AddProduct(Product product)
        {
            if (Products.Any(p => p.Id == product.Id))
                throw new Exception("Produto já está na lista de favoritos");
            Products.Add(product);
        }
    }
}
