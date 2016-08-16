using Microsoft.AspNet.Identity.EntityFramework;

namespace UnibenWeb.Infra.CrossCutting.Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UnibenWeb.Infra.CrossCutting.Identity.Context.IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UnibenWeb.Infra.CrossCutting.Identity.Context.IdentityContext context)
        {

            context.AcessoIdentityUsers.AddOrUpdate(
                u => u.Id, new IdentityUser()
                {
                    Id = "b3c8a96e-2d0c-48dc-926e-ae7202d1c583",
                    Email = "uniben.juizdefora@gmail.com",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = "c1b305f4-c1f6-41c9-bfe1-98ee240a96a7",
                    UserName = "uniben.juizdefora@gmail.com",
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = null,
                    PasswordHash = "ALT1iTKgr+zpdy4QCxnPl4w8HYD6WrQQTv+cWh3Gev0HU63ahh1yrAlmgs2QJIpk5A==",
                    LockoutEnabled = false,
                    LockoutEndDateUtc = null
                });

            context.AcessoUserClaims.AddOrUpdate(
                u => u.Id, new IdentityUserClaim()
                {
                    UserId = "b3c8a96e-2d0c-48dc-926e-ae7202d1c583",
                    ClaimType = "Adm",
                    ClaimValue = "1"
                });



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
