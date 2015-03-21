using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;
using MyLibrary.Repository;

namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        
        private BookRepository rep = new BookRepository();

        // GET: /Book/
        public ActionResult Index(string bookGenre,string filterByTitle)
        {
            var books = rep.DataContext.Books.ToList();
            var GenreList = new List<string>();
            var GenreQuery = from g in rep.DataContext.Books
                             orderby g.Genre
                             select g.Genre;

            GenreList.AddRange(GenreQuery.Distinct());
            ViewBag.BookGenre = new SelectList(GenreList);
            
            if (!String.IsNullOrWhiteSpace(filterByTitle))
            {
                books = rep.GetBooksByTitle(filterByTitle);
            }

            //if (!String.IsNullOrEmpty(bookGenre))
            //{
            //    books = books.Where(x => x.Genre == bookGenre).ToList();
            //}
            return View(books);
        }

        // GET: /Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = rep.DataContext.Books.Find(id);
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
                rep.DataContext.Books.Add(book);
                rep.DataContext.SaveChanges();
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
            Book book = rep.DataContext.Books.Find(id);
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
                rep.DataContext.Entry(book).State = EntityState.Modified;
                rep.DataContext.SaveChanges();
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
            Book book = rep.DataContext.Books.Find(id);
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
            Book book = rep.DataContext.Books.Find(id);
            rep.DataContext.Books.Remove(book);
            rep.DataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rep.DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
