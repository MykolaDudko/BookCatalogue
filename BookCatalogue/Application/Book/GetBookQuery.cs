using Library.DTOs;
using Library.Models;
using MediatR;

namespace BookCatalogue.Application.Book;

public record GetBookQuery(int Id) : IRequest<BookDTO>;

