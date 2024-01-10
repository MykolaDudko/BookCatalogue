using Library.DTOs;
using MediatR;

namespace BookCatalogue.Application.Book;

public record CreateBookCommand(BookDTO Book):IRequest<int>;