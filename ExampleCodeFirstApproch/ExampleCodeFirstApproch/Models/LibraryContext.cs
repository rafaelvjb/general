using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleCodeFirstApproch.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=DbConnectionString")
        {
        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasKey(t => t.PublisherId);
            modelBuilder.Entity<Publisher>().Property(t => t.PublisherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Book>().Property(b => b.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Book>().HasRequired(p => p.Publisher)
                .WithMany(b => b.Books).HasForeignKey(b => b.PublisherId);      
            base.OnModelCreating(modelBuilder);
        }
    }
}