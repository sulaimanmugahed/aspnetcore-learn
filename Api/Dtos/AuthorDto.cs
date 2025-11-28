using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Api.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class AuthorDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
public List<BookDto> Books { get; set; }
}