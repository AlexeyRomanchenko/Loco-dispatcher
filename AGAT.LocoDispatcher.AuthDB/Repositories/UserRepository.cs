using AGAT.LocoDispatcher.AuthDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AuthContext context;
        public UserRepository()
        {
            context = new AuthContext();
        }
        public async Task Create(User user)
        {
            context.Users.Add(user);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<User> Login(User user)
        {
            try
            {
                return await context.Users.AsNoTracking()
                    .Where(e => e.Username == user.Username && e.Password == user.Password)
                    .SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
