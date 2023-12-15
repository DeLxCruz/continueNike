using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUsuario _usuarioRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUsuario usuarioRepository, UserManager<ApplicationUser> userManager)
        {
            _usuarioRepository = usuarioRepository;
            _userManager = userManager;
        }

        public async Task<Usuario> AuthenticateAsync(string username, string password)
        {
            var user = await _usuarioRepository.GetByUsernameAsync(username);

            if (user != null && VerifyPassword(user, password))
            {
                return user;
            }
            return null;
        }

        private bool VerifyPassword(Usuario user, string password)
        {

            return user.Contrasena == password;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }

        public async Task<bool> RegisterAsync(string username, string password)
        {
            var userExists = await UserExistsAsync(username);
            if (userExists)
            {
                return false;
            }

            var newUser = new ApplicationUser { UserName = username };

            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Cliente");
                return true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception(error.Description);
                }
                return false;
            }
        }
    }
}