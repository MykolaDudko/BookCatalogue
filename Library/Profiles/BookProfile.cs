using AutoMapper;
using Library.DTOs;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Profiles;
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookModel, BookDTO>();
        CreateMap<BookDTO, BookModel>();
        CreateMap<BookModel, BookModel>();
    }
}
