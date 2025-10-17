using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        [NotMapped]
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Image { get; private set; }
        public FavoriteList FavoriteList { get; private set; }
        public Guid FavoriteListId { get; private set; }
        public Product(int id, string title, string description, string category, string image, Guid favoriteListId)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Image = image;
            FavoriteListId = favoriteListId;
        }
    }
}
