using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.Common.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    interface IUserRepository
    {
        void Create(User user);
        Task<User> GetAsync(User user);
        Task<User> GetByIdAsync(int id);
        void Remove(User user);
        Task<IEnumerable<UserRole>> GetAllAsync();
    }
}
