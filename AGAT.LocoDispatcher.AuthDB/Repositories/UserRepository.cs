using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Utils;
using AGAT.LocoDispatcher.Common.Models.ViewModels;
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
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
        }

        public async Task<User> GetAsync(User user)
        {
            try
            {
                var loggedUser =  await context.Users.AsNoTracking()
                    .Where(e => e.Username == user.Username)
                    .Include(e=>e.Role).Include(e=>e.Station)
                    .SingleOrDefaultAsync();
                return loggedUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            try
            {
                return await context.Users
                  .AsNoTracking()
                  .Include(e => e.Role)
                  .Include(s=>s.Station)
                  .Select(
                  u =>
                  new UserRole
                  {
                      Id = u.Id,
                      Station = u.Station.Name +"("+ u.Station.StationCode+")",
                      Username = u.Username,
                      Role = u.Role.Name
                  }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {       
                return await context.Users.Include(u=>u.Role).Where(e => e.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
