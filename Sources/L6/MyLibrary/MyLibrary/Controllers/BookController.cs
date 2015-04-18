using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Core.Models;
//using MyLibrary.Repository;
using MyLibrary.Models.Interfaces;
using BookServiceClient;


namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        
        private IBookService bookService;

        public BookController(IBookService service)
        {
            this.bookService = service;
                //new BookServiceClient.BookServiceClient("http://localhost/MyLibrary.BookService/api/");
        }

        // GET: /Book/
        public ActionResult Index(string bookGenre,string filterByTitle)
        {

            var books = bookService.List( bookGenre, filterByTitle);

           var genreList = bookService.Genres();
           if (genreList == null)
               genreList = new List<string>();
           ViewBag.BookGenre = new SelectList(genreList);

         
            return View(books);
        }

        // GET: /Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.FindBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Author,Isbn,PubDate,Genre")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.FindBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Author,Isbn,PubDate,Genre")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.FindBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            bookService.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: /Book/Edit/5
        public ActionResult Lend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookService.FindBookById(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                Lending lending = new Lending();
                lending.Book = book;
                lending.UserName = User.Identity.Name;
                lending.LendingDate = DateTime.Now;

                bookService.Lend(lending);
            }

           
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // bookService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
