using System;
using MyLibrary.Core.Models;
using System.Collections.Generic;
namespace BookServiceClient
{
    public interface IBookService
    {
        Book FindBookById(int? id);
        IEnumerable<Book> List(string bookGenre, string filterByTitle);
        IEnumerable<string> Genres();
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
    }
}
