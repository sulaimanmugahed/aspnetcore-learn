using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;


[ApiController]
[Route("[controller]")]
public class RolesController(RoleManager<IdentityRole> roleManager) : ControllerBase
{
    [HttpDelete("{roleName}")]
    public async Task<IActionResult?> Delete(string roleName)
    {
        var role = await roleManager.FindByNameAsync(roleName);
        if (role is null)
        {
            return NotFound();
        }
       var result = await roleManager.DeleteAsync(role);
       if(!result.Succeeded)
        {
            return NotFound();
        }
        return Ok();

    }

    [HttpPost]
    public async Task<IActionResult> Create(string name)
    {
        var role = new IdentityRole
        {
            Name = name
        };
        var result = await roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpGet("{roleName}")]
    public async Task<IdentityRole?> Get(string roleName)
    {
        return await roleManager.FindByNameAsync(roleName);
    }

    [HttpGet]
    public async Task<List<IdentityRole>> GetAll()
    {
        return await roleManager.Roles.ToListAsync();
    }
}
