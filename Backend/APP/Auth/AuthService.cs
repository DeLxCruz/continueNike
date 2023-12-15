using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.Auth.Token;
using Domain.Interfaces;

namespace APP.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<AuthResult> AuthenticateAsync(string username, string password)
        {
            var user = await _userService.AuthenticateAsync(username, password);

            if (user == null)
                return new AuthResult { Success = false };

            var token = await _tokenService.GenerateJwtToken(user);
            var refreshToken = await _tokenService.GenerateRefreshToken(user.Id);

            return new AuthResult { Success = true, Token = token, RefreshToken = refreshToken };
        }
    }
}