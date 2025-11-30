using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain;

public class Author : Entity
{
       public string Name { get; set; }
       public Author(int id, string name)
       {
              Name = name;
              Id = id;

       }

       public Author(string name)
       {
              Name = name;

       }
       public List<BookAuthor> Books { get; set; }
}
