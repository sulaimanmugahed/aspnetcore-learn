using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Extensions;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IBookRepository repository) : ControllerBase
{
    [HttpGet]
    public List<BookDto> GetAll()
    {
        var books = repository.GetAll();
        var bookDtos = books.Select(book => book.ToDto()).ToList();
        return bookDtos;
    }
    [HttpPost]
    public void Create(CreateBookDto request)
    {
        var book = new Book
        {
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity,
            CategoryId = request.CategoryId,
            Authors = request.Authors.Select(a => new BookAuthor
            {
                AuthorId = a
            }).ToList()

        };
        repository.Create(book);
    }
    [HttpPost("buy")]
    public BuyResult Buy(BuyRequest request)
    {
        return repository.Buy(request.CustomerId, request.BookId, request.Quantity);
    }

    // [HttpGet("{customerId}/{bookId}/{quantity}")]
    // public BuyResult Buy(int customerId,int bookId,int quantity)
    // {
    //     return database.BuyBook(customerId, bookId, quantity);
    // }

    [HttpGet("{id}")]
    public BookDto? Get(int id)
    {
        var book = repository.Get(id);
        return book?.ToDto();
    }
    [HttpGet("{id}/detail")]
    public BookDetailDto? GetBookDetail(int id)
    {
        var book = repository.GetDetail(id);
        var bookDto = book?.ToDetailDto();
        return bookDto;
    }
    [HttpGet("{id}/exist")]
    public bool Exist(int id)
    {
        return repository.Exist(id);
    }






}

public class BuyRequest
{
    public int CustomerId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
}



// Route Parameter ,required
// Query Parameter , optional

