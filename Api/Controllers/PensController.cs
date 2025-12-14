using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PensController(IRepository<Pen> repository) : ControllerBase
{
    [HttpPost("{dto}")]
    public IActionResult Create(CreatePenDto dto)
    {
        var pen = new Pen()
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity

        };
        repository.Create(pen);

        return Ok();

    }
    [HttpGet("{id}")]
    public ActionResult<PenDto> Get(int id)
    {
        var pen = repository.Get(id);

        if (pen is null)
        {
            return NotFound();
        }
        var dto = new PenDto()
        {
            Name = pen.Name,
            Price = pen.Price
        };

        return Ok(dto);
    }

}
