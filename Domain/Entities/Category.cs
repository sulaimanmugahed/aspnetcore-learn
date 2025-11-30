using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain;

public class Category : Entity
{

    public string? Name { get; set; }
    public List<Book> Books { get; set; } = [];

}
