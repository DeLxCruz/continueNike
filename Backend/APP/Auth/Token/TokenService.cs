using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace APP.Auth.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuario _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IConfiguration configuration, IUsuario userRepository, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateJwtToken(Usuario user)
        {
            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMonths(1)
            };

            _userRepository.AddRefreshToken(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            return refreshToken.Token;
        }

        public async Task<string> GenerateRefreshToken(int userId)
        {
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMonths(1)
            };

            _userRepository.AddRefreshToken(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            return refreshToken.Token;
        }
    }
}