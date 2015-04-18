using MyLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Repository
{
    public class LendingRepository : RepositoryBase<BookContext>, ILendingRepository
    {

    }
}
