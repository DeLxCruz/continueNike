using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace APP.Repositories
{
    public class UsuarioRepository(NikeContext context) : GenericRepository<Usuario>(context), IUsuario
    {
        private readonly NikeContext _context = context;

        public void AddRefreshToken(RefreshToken refreshToken)
        {
            var existingUser = _context.Set<Usuario>()
                .Include(u => u.RefreshTokens)
                .SingleOrDefault(u => u.Id == refreshToken.UserId);

            if (existingUser == null)
            {
                throw new InvalidOperationException("El usuario no fue encontrado.");
            }

            existingUser.RefreshTokens.Add(refreshToken);

            // Guarda los cambios en la base de datos
            _context.SaveChanges();
        }

        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            // Implementa la lógica para obtener el usuario por nombre de usuario
            // Aquí se asume que en tu entidad Usuario tienes una propiedad 'Username'
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == username);
        }
    }
}