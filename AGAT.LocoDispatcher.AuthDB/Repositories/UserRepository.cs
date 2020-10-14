using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Utils;
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
        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(User user)
        {
            try
            {
                var loggedUser =  await context.Users.AsNoTracking()
                    .Where(e => e.Username == user.Username)
                    .Include(e=>e.Role)
                    .SingleOrDefaultAsync();
                return loggedUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
