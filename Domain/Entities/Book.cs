using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain;


public class Book : Entity, IHasQuantity
{

    public Book()
    {

    }

    public Book(int id, string name, int price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<BookAuthor> Authors { get; set; }

}


