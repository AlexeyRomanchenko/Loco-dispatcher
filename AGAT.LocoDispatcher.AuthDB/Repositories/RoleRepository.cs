using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private AuthContext _context;
        public RoleRepository()
        {
            _context = new AuthContext();
        }
        public async Task<IEnumerable<RoleViewModel>> GetAsync()
        {
            return await _context.Roles.AsNoTracking()
                .Select(r=> new RoleViewModel 
                { RoleId = r.RoleId, Name = r.Name }).ToListAsync();
        }
    }
}
