using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Data
{
    public class AuthDbContext : IdentityDbContext

    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "1eedb526-e85b-4698-8ba8-574d3a102912";
            var writerRoleId = "8ba1f632-fd13-4a47-9f4a-eb630545f713";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER",
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER",
                    ConcurrencyStamp = writerRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Admin user seeding
            var adminUserId = "2997c46b-3629-4930-babe-628b9fccc01b";
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@beantea.com",
                Email = "admin@beantea.com",
                NormalizedEmail = "ADMIN@BEANTEA.COM",
                NormalizedUserName = "ADMIN@BEANTEA.COM"
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin); 

            // Assign Reader and Writer roles to Admin
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = readerRoleId },
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = writerRoleId }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}