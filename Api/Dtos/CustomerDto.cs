using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Api.Dtos;

public class CustomerDto
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public int Balance { get; set; }

}
public class CustomerDetailDto
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public int Balance { get; set; }
    public UserDto User { get; set; }

}
