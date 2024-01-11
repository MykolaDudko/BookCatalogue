using AutoMapper;
using Library.Repositories;
using MediatR;

namespace BookCatalogue.Application.Book;

public class DeleteCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly BookRepository _repository;

    public DeleteCommandHandler( BookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken ct)
    {
        var query = _repository.GetEntityLinqQueryable();
        query = query.Where(i=>i.Id == request.Id); 
        await _repository.DeleteAsync(query, ct);
    }
}
