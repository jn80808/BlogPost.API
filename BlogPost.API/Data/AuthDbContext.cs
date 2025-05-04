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

            //Create Reader and Writer Role 
            var roles = new List<IdentityRole> {

                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }

            };

            //Seed the role for Reader & Writer
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an Admin User 
            var adminUserId = "2997c46b-3629-4930-babe-628b9fccc01b";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@beantea.com",
                Email = "admin@beantea.com",
                NormalizedEmail = "admin@beantea.com".ToUpper(),
                NormalizedUserName = "admin@beante.com".ToUpper()

            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            //Seed the role for Admin 
            builder.Entity<IdentityRole>().HasData(admin);


            //Give Role To Admin 
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new ()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId,

                },
                new ()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId,

                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
        

    }
}
