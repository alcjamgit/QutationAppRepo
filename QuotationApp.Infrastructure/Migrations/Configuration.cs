namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using QuotationApp.Infrastructure.DataLayer;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<QuotationApp.Infrastructure.DataLayer.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuotationApp.Infrastructure.DataLayer.ApplicationDbContext context)
        {
            SeedAdminUsers(context);
        }

                /// <summary>
        /// Seed admin user
        /// </summary>
        /// <param name="context"></param>
        private void SeedAdminUsers(ApplicationDbContext context)
        {
            var adminuser = "admin1@gmail.com";
            var userRole = "admin";
            var pwd = "abc123";

            if (!context.Roles.Any(r => r.Name == userRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = userRole };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == adminuser))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = adminuser };

                manager.Create(user, pwd);
                manager.AddToRole(user.Id, userRole);
            }
        }
    }
}
