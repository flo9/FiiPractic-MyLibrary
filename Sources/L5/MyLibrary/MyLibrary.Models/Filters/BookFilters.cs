using MyLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Filters
{
    public static class BookFilters
    {
        public static IQueryable<Book> WithTitle(this IQueryable<Book> query, string title)
        {
            if (!String.IsNullOrWhiteSpace(title))
                return query.Where(b => b.Title.Contains(title));
            else
                return query;
        }

        public static IQueryable<Book> WithGenre(this IQueryable<Book> query, string genre)
        {
            if (!String.IsNullOrWhiteSpace(genre))
                return query.Where(b => b.Genre == genre);
            else
                return query;
        }
    }
}
