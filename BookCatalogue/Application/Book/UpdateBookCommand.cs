using Library.DTOs;
using MediatR;

namespace BookCatalogue.Application.Book;

public record UpdateBookCommand(BookDTO Book, int Id) : IRequest;

