﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;
public class BookModel : Entity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime Publication {  get; set; }  
}
