using BookCatalogue.Application.Book;
using Library.DTOs;
using Library.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogue.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ISender _mediator;

    public BookController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<BookDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var query = new GetAllBooksQuery();
        var book = await _mediator.Send(query, cancellationToken: ct);
        return Ok(book);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<BookDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> Get(CancellationToken ct, int id)
    {
        var query = new GetBookQuery(id);
        var book = await _mediator.Send(query, cancellationToken: ct);
        return Ok(book);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> Create(CancellationToken ct, BookDTO book)
    {
        var query = new CreateBookCommand(book);
        var carrierBranchCategory = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carrierBranchCategory);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> Update(CancellationToken ct, BookDTO book, int id)
    {
        var command = new UpdateBookCommand(book, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> Delete(CancellationToken ct, int id)
    {
        var command = new DeleteBookCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
