using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos;

public class CreateCustomerDto
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
}
