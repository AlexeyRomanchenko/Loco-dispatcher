using AGAT.LocoDispatcher.AuthDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB
{
    public class AuthContext : DbContext
    {
        private static string databaseString;
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AuthContext(): base("AuthContext") {}

        public static void SetDatabaseString(string connection)
        {
            databaseString = $"name={connection}";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasRequired<Role>(e => e.Role).WithMany(e => e.Users).HasForeignKey<int>(e => e.RoleId);
        }
    }
}
