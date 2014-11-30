using ExampleCodeFirstApproch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleCodeFirstApproch.Controllers
{
    public class BookController : Controller
    {
        LibraryContext objContext;

        public BookController()
        {
            objContext = new LibraryContext();
        }

        #region List and Details Block
        public ActionResult Index()
        {
            var books = objContext.Book.ToList();

            return View(books);
        }

        public ViewResult Details(int id)
        {
            Book book = objContext.Book.Where(x => x.BookId == id).SingleOrDefault();
            return View(book);
        }

        #endregion
        #region Create Publisher
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            objContext.Book.Add(book);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit Book
        public ActionResult Edit(int id)
        {
            Book book = objContext.Book.Where(x => x.BookId == id).SingleOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book model)
        {
            Book book = objContext.Book.Where(x => x.BookId == model.BookId).SingleOrDefault();
            if (book != null)
            {
                objContext.Entry(book).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Delete Book
        public ActionResult Delete(int id)
        {
            Book book = objContext.Book.Find(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(int id, Publisher model)
        {
            var book = objContext.Book.Where(x => x.BookId == id).SingleOrDefault();
            if (book != null)
            {
                objContext.Book.Remove(book);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}