using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EF.Data;
using EF.Core.Data;

namespace EF.UnitTest
{
    /// <summary>
    /// Summary description for CustomerTest
    /// </summary>
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void CustomerOrderTest()
        {
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());

            using (var context = new EFDbContext())
            {
                context.Database.CreateIfNotExists();
                Customer customer = new Customer()
                {
                    Name = "Rafael",
                    Email = "email@email.com",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IP = "1.1.1.1",
                    Orders = new List<Order>(){
                        new Order(){
                            Quantity = 2,
                            Price = 109,
                            AddedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            IP = "1.1.1.1"
                        },
                        new Order(){
                            Quantity =12,
                            Price = 09,
                            AddedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            IP = "1.1.1.1"
                        }
                    }
                };

                context.Entry(customer).State = System.Data.Entity.EntityState.Added;

                context.SaveChanges();
            }
        }
    }
}
