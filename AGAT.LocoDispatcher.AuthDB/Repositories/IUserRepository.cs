using AGAT.LocoDispatcher.AuthDB.Models;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    interface IUserRepository
    {
        Task Create(User user);
        Task<User> Login(User user);
    }
}
