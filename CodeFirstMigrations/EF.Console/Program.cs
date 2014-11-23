using System;
using EF.Data;
using EF.Core;

namespace EF.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter your name : ");
            string name = System.Console.ReadLine();
            System.Console.Write("Enter your age : ");
            int age = 0;
            Int32.TryParse(System.Console.ReadLine(), out age);

            using (EFDbContext context = new EFDbContext())
            {
                Student student = new Student { Name = name, Age = age };
                context.Entry(student).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            System.Console.ReadLine();   
        }
    }
}
