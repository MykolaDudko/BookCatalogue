using AutoFixture;
using AutoMapper;
using BookCatalogue.Application.Book;
using BookCatalogue.Controllers;
using Library.Context;
using Library.DTOs;
using Library.Models;
using Library.Profiles;
using Library.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogueTest;
public class BookTest
{
    private readonly Fixture _autoFixture;
    private readonly Mock<ISender> _mediatorMock;
    private readonly BookController _controller;

    public BookTest()
    {
        _autoFixture = new Fixture();
        _mediatorMock = new Mock<ISender>();
        _controller = new BookController(_mediatorMock.Object);
    }
    [Fact]
    public async Task GetAll_ReturnsOk_WithBooks()
    {
        // Arrange
        var books = _autoFixture.CreateMany<BookDTO>();
        Response<BookDTO> mockBooksResponse = new Response<BookDTO>(books.Count(), books.ToList());
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(mockBooksResponse);

        // Act
        var result = await _controller.GetAll(new CancellationToken());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Response<BookDTO>>(okResult.Value);
        Assert.Equal(mockBooksResponse, returnValue);
    }

    [Fact]
    public async Task Get_ShouldReturnOk_WhenBookExists()
    {
        // Arrange
        var bookId = 1;
        var mockBook = _autoFixture.Create<BookDTO>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(mockBook);

        // Act
        var result = await _controller.Get(CancellationToken.None, bookId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(mockBook, okResult.Value);
    }
    [Fact]
    public async Task Create_ShouldReturnOk_WhenBookIsCreated()
    {
        // Arrange
        var mockBook = _autoFixture.Create<BookDTO>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBookCommand>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(1); 

        // Act
        var result = await _controller.Create(CancellationToken.None, mockBook);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(1, okResult.Value); 
    }
    [Fact]
    public async Task Update_ShouldReturnOk_WhenBookIsUpdated()
    {
        // Arrange
        var bookId = 1;
        var mockBook = _autoFixture.Create<BookDTO>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBookCommand>(), It.IsAny<CancellationToken>()))
                     .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Update(CancellationToken.None, mockBook, bookId);

        // Assert
        Assert.IsType<OkResult>(result);
    }
    [Fact]
    public async Task Delete_ShouldReturnOk_WhenBookIsDeleted()
    {
        // Arrange
        var bookId = 1;
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBookCommand>(), It.IsAny<CancellationToken>()))
                     .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(CancellationToken.None, bookId);

        // Assert
        Assert.IsType<OkResult>(result);
    }

}
