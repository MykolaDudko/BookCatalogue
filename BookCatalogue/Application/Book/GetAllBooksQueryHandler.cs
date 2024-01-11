using AutoMapper;
using Library.DTOs;
using Library.Models;
using Library.Repositories;
using MediatR;

namespace BookCatalogue.Application.Book;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, Response<BookDTO>>
{
    private readonly BookRepository _repository;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IMapper mapper, BookRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken ct)
    {
        var response = await _repository.GetAllAsync();
        return new Response<BookDTO>(response.Count, _mapper.Map<List<BookDTO>>(response));
    }
}
