using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Repository
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<MyLibrary.Models.Book> Books { get; set; }
    }
}
