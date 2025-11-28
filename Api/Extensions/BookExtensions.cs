using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Domain;

namespace Api.Extensions;

public static class BookExtensions
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            Quantity = book.Quantity
        };

    }
    public static BookDetailDto ToDetailDto(this Book book)
    {
        return new BookDetailDto
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            Quantity = book.Quantity,
            Category = new CategoryDto
            {
                Id = book.CategoryId,
                Name = book.Category.Name
            },
            Authors = book.Authors.Select(a => new AuthorDto
            {
                Id = a.AuthorId,
                Name = a.Author.Name

            }).ToList()
        };
    }

}
