using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CandidateManagement.Data
{
    public class SecurityContext : IdentityDbContext<IdentityUser>
    {
        public SecurityContext()
            : base("CMContext")
        {
            base.OnModelCreating(new DbModelBuilder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var user = modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id).ToTable("User", "Users"); //Specify our our own table names instead of the defaults

            //user.Property(iu => iu.Id).HasColumnName("Id");
            //user.Property(iu => iu.UserName).HasColumnName("UserName");
            //user.Property(iu => iu.Email).HasColumnName("EmailAddress").HasMaxLength(254).IsRequired();
            //user.Property(iu => iu.PasswordHash).HasColumnName("PasswordHash");
            //user.Property(iu => iu.SecurityStamp).HasColumnName("SecurityStamp");

            //user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            //user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            //user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            //user.Property(u => u.UserName).IsRequired();

            //var applicationUser = modelBuilder.Entity<IdentityUser>().HasKey(au => au.Id).ToTable("User", "Users"); //Specify our our own table names instead of the defaults

            //applicationUser.Property(au => au.Id).HasColumnName("Id");
            //applicationUser.Property(au => au.UserName).HasMaxLength(50).HasColumnName("UserName");
            //applicationUser.Property(au => au.PasswordHash).HasColumnName("PasswordHash");
            //applicationUser.Property(au => au.SecurityStamp).HasColumnName("SecurityStamp");
            //applicationUser.Property(au => au.Email).HasColumnName("EmailAddress").HasMaxLength(254).IsRequired();

            //var role = modelBuilder.Entity<IdentityRole>().HasKey(ir => ir.Id).ToTable("ApplicationRole", "Users");

            //role.Property(ir => ir.Id).HasColumnName("Id");
            //role.Property(ir => ir.Name).HasColumnName("Name");

            //var claim = modelBuilder.Entity<IdentityUserClaim>().HasKey(iuc => iuc.Id).ToTable("UserClaim", "Users");

            //claim.Property(iuc => iuc.Id).HasColumnName("Id");
            //claim.Property(iuc => iuc.ClaimType).HasColumnName("ClaimType");
            //claim.Property(iuc => iuc.ClaimValue).HasColumnName("ClaimValue");
            //claim.Property(iuc => iuc.UserId).HasColumnName("UserId");

            //var login = modelBuilder.Entity<IdentityUserLogin>().HasKey(iul => new { iul.UserId, iul.LoginProvider, iul.ProviderKey }).ToTable("UserLogin", "Users"); //Used for third party OAuth providers

            //login.Property(iul => iul.UserId).HasColumnName("UserId");
            //login.Property(iul => iul.LoginProvider).HasColumnName("LoginProvider");
            //login.Property(iul => iul.ProviderKey).HasColumnName("ProviderKey");

            //var userRole = modelBuilder.Entity<IdentityUserRole>().HasKey(iur => new { iur.UserId, iur.RoleId }).ToTable("UserRole", "Users");

            //userRole.Property(ur => ur.UserId).HasColumnName("UserId");
            //userRole.Property(ur => ur.RoleId).HasColumnName("RoleId");
        }
    }
}
