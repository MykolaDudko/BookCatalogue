using Library.Context;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories;
public class BookRepository : BaseRepository<BookModel>
{
    public BookRepository(BookContext dbContext) : base(dbContext)
    {           
    }
}
