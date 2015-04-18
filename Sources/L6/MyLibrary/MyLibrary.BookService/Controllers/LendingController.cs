using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyLibrary.Core.Models;
using MyLibrary.Repository;

namespace MyLibrary.BookService.Controllers
{
    public class LendingController : ApiController
    {
        private BookContext db = new BookContext();
        private BookRepository bookRep = new BookRepository();

        // GET api/Lending
        public IQueryable<Lending> GetLendings()
        {
            return db.Lendings;
        }

        // GET api/Lending/5
        [ResponseType(typeof(Lending))]
        public IHttpActionResult GetLending(int id)
        {
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return NotFound();
            }

            return Ok(lending);
        }

        // PUT api/Lending/5
        public IHttpActionResult PutLending(int id, Lending lending)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lending.ID)
            {
                return BadRequest();
            }

            db.Entry(lending).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LendingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Lending
        [ResponseType(typeof(Lending))]
        public IHttpActionResult PostLending(Lending lending)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
         //   var book = bookRep.FindById(lending.Book.ID);
        //    book.AvailableCount -= 1;
        //    bookRep.Update<Book>(book);

            db.Lendings.Add(lending);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lending.ID }, lending);
        }

        // DELETE api/Lending/5
        [ResponseType(typeof(Lending))]
        public IHttpActionResult DeleteLending(int id)
        {
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return NotFound();
            }

            db.Lendings.Remove(lending);
            db.SaveChanges();

            return Ok(lending);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LendingExists(int id)
        {
            return db.Lendings.Count(e => e.ID == id) > 0;
        }
    }
}