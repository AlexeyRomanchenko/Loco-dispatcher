using AGAT.LocoDispatcher.AuthDB.Models;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    interface IUserRepository
    {
        void Create(User user);
        Task<User> GetAsync(User user);
    }
}
