using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.DAL
{
    public class BookRepository:IBookRepository
    {
        private BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }




        public IEnumerable<BookStore.Models.Book> GetBooks()
        {
            var books = _context.Books;
            return books.ToList();
        }

        public Book GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }

        public void InsertBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int bookID)
        {
            Book book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        //tratamento para dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}