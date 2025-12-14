using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos;

public class CreatePenDto
{
    public string? Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}
