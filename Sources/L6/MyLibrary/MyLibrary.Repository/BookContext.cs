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
        public System.Data.Entity.DbSet<MyLibrary.Core.Models.Book> Books { get; set; }
        public System.Data.Entity.DbSet<MyLibrary.Core.Models.Lending> Lendings { get; set; }
    }
}
