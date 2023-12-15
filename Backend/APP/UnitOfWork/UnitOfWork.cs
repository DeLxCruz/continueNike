using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.UnitOfWork
{
    public class UnitOfWork(NikeContext context) : IUnitOfWork, IDisposable
    {
        private readonly NikeContext _context = context;
        private IUsuario _usuarios;
        private IRole _roles;

        public IUsuario Usuarios
        {
            get
            {
                _usuarios ??= new UsuarioRepository(_context);
                return _usuarios;
            }
        }

        public IRole Roles
        {
            get
            {
                _roles ??= new RoleRepository(_context);
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}