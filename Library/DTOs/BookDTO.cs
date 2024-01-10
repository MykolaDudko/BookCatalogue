using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTOs;
public class BookDTO
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateOnly Publication { get; set; }
}
