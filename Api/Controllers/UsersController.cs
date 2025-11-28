using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Extensions;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserRepository repository, IRepository<User> repo) : ControllerBase
{
    [HttpGet]
    public List<UserDto> GetAll()
    {
        var user = repo.GetAll();
        var dto = user.Select(user => user.ToDto()).ToList();

        return dto;


    }
    [HttpGet("{id}")]
    public UserDto? Get(int id)
    {
        var user = repo.Get(id);
        var dto = user?.ToDto();
        return dto;

    }
    [HttpPost]
    public void Create(CreateUserDto dto)
    {
        var user = new User()
        {
            Password = dto.Password,
            UserName = dto.UserName

        };
        repo.Create(user);

    }

}




