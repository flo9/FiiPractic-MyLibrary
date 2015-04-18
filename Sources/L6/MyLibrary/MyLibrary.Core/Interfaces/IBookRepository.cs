using MyLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Models.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooksByTitle(string title);
        Book FindById(int? id);
      //  BookContext DataContext { get; }
        bool AllowSerialization { get; set; }
        T Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class;

        IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderBy) where T : class;

        IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class;
        IQueryable<T> GetList<T>() where T : class;
        OperationStatus Save<T>(T entity) where T : class;
        OperationStatus Update<T>(T entity, params string[] propsToUpdate) where T : class;
        OperationStatus ExecuteStoreCommand(string cmdText, params object[] parameters);

        IEnumerable<string> GenreList();

        void Dispose();
    }
}
