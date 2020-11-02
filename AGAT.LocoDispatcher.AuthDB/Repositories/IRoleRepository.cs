using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    interface IRoleRepository
    {
        Task<IEnumerable<RoleViewModel>> GetAsync();
    }
}
