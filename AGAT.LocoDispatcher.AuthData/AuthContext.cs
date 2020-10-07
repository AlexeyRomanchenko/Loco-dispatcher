using AGAT.LocoDispatcher.AuthData.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AGAT.LocoDispatcher.AuthData
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext() : base("AuthContext") { }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>()
            .HasKey(r => new { r.UserId, r.RoleId })
            .ToTable("AspNetUserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                        .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                        .ToTable("AspNetUserLogins");

        }
    }
}
