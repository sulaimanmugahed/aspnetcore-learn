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
public class AuthorsController(IAuthorRepository repository) : ControllerBase
{

    [HttpGet]
    public async Task<List<AuthorDto>> GetAll()
    {

        var authors = await repository.GetAllAsync();
        var authorDtos = authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name
        }).ToList();
        return authorDtos;

    }
    [HttpPost]
    public async Task Create(CreateAuthorDto dto)
    {
        var author = new Author(dto.Name);
        await repository.CreateAsync(author);
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        await repository.DeleteAsync(id);

    }
    [HttpGet("{id}")]
    public async Task<AuthorDto?> GetAuthor(int id)
    {

        var author = await repository.GetAsync(id);
        var dto = new AuthorDto
        {
            Id = author.Id,
            Name = author.Name

        };
        return dto;

    }
    [HttpGet("{id}/detail")]
    public async Task<AuthorDetailDto?> GetAuthorDetail(int id)
    {
        var author = await repository.GetDetailAsync(id);
        var dto = new AuthorDetailDto
        {
            Id = author.Id,
            Name = author.Name,
            Books = author.Books.Select(a => a.Book.ToDto()).ToList()

        };
        return dto;

    }



}
