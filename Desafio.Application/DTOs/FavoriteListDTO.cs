using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.DTOs
{
    public class FavoriteListDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public Guid ClientId { get; set; }
        public IEnumerable<ProductDTO>? Products { get; set; }
    }
}
