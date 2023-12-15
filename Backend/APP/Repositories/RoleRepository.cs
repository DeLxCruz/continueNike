using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repositories
{
    public class RoleRepository(NikeContext context) : GenericRepository<Role>(context), IRole
    {
        private readonly NikeContext _context = context;
    }
}