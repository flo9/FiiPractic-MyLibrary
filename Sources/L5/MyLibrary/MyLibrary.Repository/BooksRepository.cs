using System.Linq.Expressions;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Models.Interfaces;

namespace MyLibrary.Repository
{
   

    public class BookRepository : RepositoryBase<BookContext>, IBookRepository
    {
        public List<Book> GetBooksByTitle(string title)
        {
            return DataContext.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public Book FindById(int? id)
        {
            return DataContext.Books.Find(id);
        }
    }
}
