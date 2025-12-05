using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Extensions;
using Api.Settings;
using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ILogger<UsersController> logger, IUserRepository repository, IOptions<PasswordSettings> options) : ControllerBase
{
    [HttpGet]
    public List<UserDto> GetAll()
    {
        var user = repository.GetAll();
        var dto = user.Select(user => user.ToDto()).ToList();

        return dto;
    }

    //error
    //information
    //warring
    [HttpGet("{id}")]
    public ActionResult<UserDto> Get(int id)
    {
        var user = repository.Get(id);
        if (user is null)
        {
            logger.LogError($"no user found with this id: {id}");
            return NotFound();
        }

        var dto = user.ToDto();

        return Ok(dto);

    }
    [HttpPost]
    public ActionResult Create(CreateUserDto dto)
    {
        if (dto.Password.Length < options.Value.Long)
        {
            return BadRequest("ggg");
        }

        var user = new User()
        {
            Password = dto.Password,
            UserName = dto.UserName

        };
        repository.Create(user);
        logger.LogInformation("new user created with username: {yyy} {jjj}", user.Id, user.UserName);

        return Ok();

    }

}




