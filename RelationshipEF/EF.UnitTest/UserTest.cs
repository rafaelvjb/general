using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EF.Core.Data;
using EF.Data;

namespace EF.UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserUserProfileTest()
        {
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
            using (var context = new EFDbContext())
            {
                context.Database.Create();
                User user = new User
                {
                    UserName = "ss_shekhawat",
                    Password = "123",
                    Email = "sandeep.shekhawat88@test.com",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IP = "1.1.1.1",
                    UserProfile = new UserProfile
                    {
                        FirstName = "Sandeep",
                        LastName = "Shekhawat",
                        Address = "Jaipur and Jhunjhunu",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IP = "1.1.1.1"
                    },
                };
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }  
    }
}
