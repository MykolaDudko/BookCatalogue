using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Context;
public class BookContext : DbContext
{
    public DbSet<BookModel> Books { get; set; } = null!;
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }
}
