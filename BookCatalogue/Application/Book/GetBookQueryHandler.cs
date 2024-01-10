using AutoMapper;
using Library.DTOs;
using Library.Models;
using Library.Repositories;
using MediatR;

namespace BookCatalogue.Application.Book;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDTO>
{
    private readonly BookRepository _repository;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IMapper mapper, BookRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookDTO> Handle(GetBookQuery request, CancellationToken ct)
    {
        var query = _repository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id);
        var book = await _repository.GetAsync(query, ct);
        return _mapper.Map<BookModel, BookDTO>(book);
    }
}
