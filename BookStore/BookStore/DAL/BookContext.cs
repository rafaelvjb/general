using BookStore.Models;
using System.Data.Entity;

namespace BookStore.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=BookStoreConnectionString")
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}