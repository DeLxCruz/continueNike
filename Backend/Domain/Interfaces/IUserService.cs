using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(string username, string password);
        Task<bool> UserExistsAsync(string username);
    }
}
