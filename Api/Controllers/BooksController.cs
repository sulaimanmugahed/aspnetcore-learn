using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Extensions;
using Api.Settings;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IBookRepository repository, ICustomerRepository customerRepository, IBorrowingRepository borrowingRepository, IOptions<BuyBookSettings> options) : ControllerBase
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
        if (options.Value.MaxQuantity < request.Quantity)
        {
            throw new Exception("aa");
        }
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
    public IActionResult Borrow(BorrowBookDto dto)
    {
        var book = repository.Get(dto.BookId);
        if (book is null)
        {
            return NotFound();
        }

        if (book.Quantity <= 0)
        {
            return BadRequest();
        }

        var customer = customerRepository.Get(dto.CustomerId);
        if (customer is null)
        {
            return NotFound();
        }

        var borrow = new Borrowing()
        {
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        borrowingRepository.Create(borrow);
        return Ok();
    }

    public ActionResult<List<BorrowingDto>> GetActiveBorrowings()
    {
        var borrowings = borrowingRepository.GetAllWhere(x => x.IsActive);
        var borrowingDtos = borrowings.Select(b => new BorrowingDto()
        {
            Id = b.Id,
            StartDate = b.StartDate,
            EndDate = b.EndDate,
            CustomerId = b.CustomerId,
            BookId = b.BookId,
            IsActive = b.IsActive
        }).ToList();

        return Ok(borrowingDtos);
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

