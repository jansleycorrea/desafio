using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.DTOs
{
    public class Login
    {
        [Required(ErrorMessage = "Nome de usuário é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
