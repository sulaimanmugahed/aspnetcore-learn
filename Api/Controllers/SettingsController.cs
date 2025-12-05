using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]

public class SettingsController(IOptions<BuyBookSettings> options1) : ControllerBase
{
    [HttpGet("buy")]
    public BuyBookSettings? GetBuyBookSettings()
    {
        return options1.Value;

    }

}
