using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace APP.Auth.Token
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(Usuario user);
        Task<string> GenerateRefreshToken(int userId);
    }
}