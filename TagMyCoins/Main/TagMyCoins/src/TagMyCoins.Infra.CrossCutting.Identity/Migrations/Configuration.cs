using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TagMyCoins.Infra.CrossCutting.Identity.Context;

namespace TagMyCoins.Infra.CrossCutting.Identity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TagMyCoins.Infra.CrossCutting.Identity.Context.IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TagMyCoins.Infra.CrossCutting.Identity.Context.IdentityContext context)
        {
            var manager = new UserManager<ApplicationUser>(
                            new UserStore<ApplicationUser>(
                                new IdentityContext()));

            for (var i = 0; i < 10; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("User{0}", i.ToString()),
                    FullName = string.Format("Full Name User{0}", i.ToString()),
                    BirthDate = DateTime.Now,
                    Email = string.Format("email{0}@email.com", i.ToString()),
                    Gender = "Male"
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }
        }
    }
}
