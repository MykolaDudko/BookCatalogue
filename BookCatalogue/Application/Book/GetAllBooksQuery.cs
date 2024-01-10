using Library.DTOs;
using Library.Models;
using MediatR;

namespace BookCatalogue.Application.Book;

public record GetAllBooksQuery : IRequest<Response<BookDTO>>;
