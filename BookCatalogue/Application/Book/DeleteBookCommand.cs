using MediatR;

namespace BookCatalogue.Application.Book;

public record DeleteBookCommand(int Id) : IRequest;

