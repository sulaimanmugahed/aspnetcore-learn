using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await userManager.FindByNameAsync(username);
        if (user is null)
        {
            return Unauthorized();
        }
        var result = await signInManager.PasswordSignInAsync(user, password, false, false);

        if (!result.Succeeded)
        {
            return Unauthorized();
        }

        return Ok();
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }

    [Authorize(Roles = "admin")]
    [HttpGet("test")]
    public string TestAuth()
    {
        return "hello";
    }


}
