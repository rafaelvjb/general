using EF.Data;
using EF.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Web.Controllers
{
    public class BookController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private Repository<Book> _bookRepository;

        public BookController()
        {
            _bookRepository = _unitOfWork.Repository<Book>();
        }

        //
        // GET: /Book/

        public ActionResult Index()
        {
            IEnumerable<Book> books = _bookRepository.Table.ToList();
            return View(books);
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Book/Create
        public ActionResult CreateEditBook(int? id)
        {
            Book model = new Book();
            if (id.HasValue)
            {
                model = _bookRepository.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditBook(Book model)
        {
            if (model.ID == 0)
            {
                model.ModifiedDate = System.DateTime.Now;
                model.AddedDate = System.DateTime.Now;
                model.IP = Request.UserHostAddress;
                _bookRepository.Insert(model);
            }
            else
            {
                var editModel = _bookRepository.GetById(model.ID);
                editModel.Title = model.Title;
                editModel.Author = model.Author;
                editModel.ISBN = model.ISBN;
                editModel.Published = model.Published;
                editModel.ModifiedDate = System.DateTime.Now;
                editModel.IP = Request.UserHostAddress;
                _bookRepository.Update(editModel);
            }

            if (model.ID > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult DeleteBook(int id)
        {
            Book model = _bookRepository.GetById(id);
            return View(model);
        }

        [HttpPost, ActionName("DeleteBook")]
        public ActionResult ConfirmDeleteBook(int id)
        {
            Book model = _bookRepository.GetById(id);
            _bookRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public ActionResult DetailBook(int id)
        {
            Book model = _bookRepository.GetById(id);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
