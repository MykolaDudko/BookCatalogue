using AutoMapper;
using Library.Repositories;
using MediatR;

namespace BookCatalogue.Application.Book;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly BookRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IMapper mapper, BookRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken ct)
    {
        var query = _repository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id);
        var book = await _repository.GetAsync(query, ct);
        _mapper.Map(request.Book, book);
        await _repository.UpdateAsync(book, ct);
    }
}
