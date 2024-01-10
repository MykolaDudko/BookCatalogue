using AutoMapper;
using Library.DTOs;
using Library.Models;
using Library.Repositories;
using MediatR;

namespace BookCatalogue.Application.Book;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly BookRepository _repository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IMapper mapper, BookRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken ct)
    {
        var book = await _repository.AddAsync(_mapper.Map<BookDTO, BookModel>(request.Book), ct);
        return book;
    }
}
