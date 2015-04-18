using MyLibrary.Core.Models;
using MyLibrary.Core.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLibrary.Repository;
using Newtonsoft.Json.Schema;

namespace MyLibrary.BookService.Controllers
{
    public class BookController : ApiController
    {
        BookRepository rep = new BookRepository();

        // GET api/book
        public IEnumerable<Book> Get([FromUri] string title = "", [FromUri] string genre = "")
        {
            return rep.GetList<Book>().WithTitle(title).WithGenre(genre);
        }

        // GET api/book/5
        public Book Get(int id)
        {
            return rep.FindById(id);
        }

        // POST api/book
        public HttpResponseMessage Post([FromBody]Book book)
        {

            rep.DataContext.Books.Add(book);
            rep.DataContext.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/book/5
        public HttpResponseMessage Put(int? id, [FromBody]Book value)
        {
            if (id == null)
            {
              
              return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            Book book = rep.DataContext.Books.Find(id);
            if (book == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            book.Author = value.Author;
            book.Isbn = value.Isbn;
            book.PubDate = value.PubDate;
            book.Title = value.Title;
            book.Genre = value.Genre;

            rep.DataContext.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);;
        }

        // DELETE api/book/5
        public void Delete(int id)
        {
            var book = rep.FindById(id);

            if (book != null)
            {
                rep.Delete<Book>(book);
            }
        }
        
            
        //GET api/book/genres
        [Route("api/Book/Genres")]
        [HttpGet]
        public IEnumerable<string> Genres()
        {
            return rep.GenreList();
        }
    }
}
