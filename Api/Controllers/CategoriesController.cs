using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Api.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoriesController(ICategoryRepository repository, IRepository<Category> repo) : ControllerBase
{
    [HttpGet]
    public List<Category> GetAll()
    {
        return repo.GetAll();
    }


    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        repo.Delete(id);
    }
    [HttpPost]
    public int Create(string name)
    {
        var category = new Category()
        {
            Name = name
        };
        repo.Create(category);
        return category.Id;
    }

    [HttpGet("{id}")]
    public CategoryDto? Get(int id)
    {
        var category = repo.Get(id);
        var dto = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name

        };
        return dto;
    }

    [HttpGet("{id}/detail")]
    public CategoryDetailDto? GetDetail(int id)
    {
        var category = repository.GetDetail(id);
        var dto = new CategoryDetailDto()
        {
            Id = category.Id,
            Name = category.Name,
            Books = category.Books.Select(a => new BookDto
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price
            }).ToList()
        };
        return dto;
    }


}
