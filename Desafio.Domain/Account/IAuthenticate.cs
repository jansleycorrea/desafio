using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> RegisterUserAsync(string userName, string password);
        Task<bool> LoginUserAsync(string userName, string password);
    }
}
