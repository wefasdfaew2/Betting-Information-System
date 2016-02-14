namespace BettingInformationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using BettingInformationSystem.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<BettingInformationSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BettingInformationSystem.Data.BettingInformationSystemDbContext";
        }

        protected override void Seed(BettingInformationSystemDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
                this.CreateAdminUser(context);
            }
        }

        private void SeedUsers(BettingInformationSystemDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { UserName = "someUser", Email = "someUser@example.com" };
            userManager.Create(userToInsert, "someUserPass123");
            userStore = new UserStore<ApplicationUser>(context);
            userManager = new UserManager<ApplicationUser>(userStore);
            userToInsert = new ApplicationUser { UserName = "newUser", Email = "new_user@gmail.com" };
            userManager.Create(userToInsert, "userPass123");
        }

        private void CreateAdminUser(BettingInformationSystemDbContext context)
        {
            var adminEmail = "petar.ivanov256@gmail.com";
            var adminPass = "123456";
            var adminUsername = "petar.ivanov256@gmail.com";
            string adminRole = "Admin";

            var adminUser = new ApplicationUser()
            {
                Email = adminEmail,
                UserName = adminUsername,
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
                RequiredLength = 3
            };

            var userCreateResult = userManager.Create(adminUser, adminPass);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join(", ", userCreateResult.Errors));
            }

            //Create role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join(", ", roleCreateResult.Errors));
            }

            //Add the role to the admin
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join(", ", addAdminRoleResult.Errors));
            }
        }
    }
}