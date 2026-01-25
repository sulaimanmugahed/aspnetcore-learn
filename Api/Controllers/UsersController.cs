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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
: ControllerBase
{
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest("cant delete the user");
        }
        return Ok();
    }
    [HttpPost("addrole")]
    public async Task<IActionResult> AddRole(string userId, string roleName)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return NotFound();
        }
        var role = await roleManager.FindByNameAsync(roleName);
        if (role is null)
        {
            return NotFound();
        }
        var result = await userManager.AddToRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            return BadRequest();
        }
        return Ok();

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var user = new IdentityUser
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        var result = await userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            return BadRequest("cant create the user");
        }
        return Ok(user.Id);
    }


    [HttpGet]
    public List<IdentityUser> GetAll()
    {
        var users = userManager.Users.ToList();
        return users;
    }
    [HttpGet("roles/{id}")]
    public async Task<IActionResult?> GetRoles(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        var roles = await userManager.GetRolesAsync(user);
        return Ok(roles);

    }

    [HttpGet("{id}")]
    public async Task<IdentityUser?> Get(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        return user;
    }
}




