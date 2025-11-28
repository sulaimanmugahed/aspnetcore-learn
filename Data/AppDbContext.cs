using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
 : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Pen> Pens { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasOne(c => c.Category)
            .WithMany(a => a.Books)
            .HasForeignKey(e => e.CategoryId);
        });
        modelBuilder.Entity<Customer>(a =>
        {
            a.HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<Customer>(c => c.UserId);
        });

        modelBuilder.Entity<BookAuthor>(x =>
        {
            x.HasKey(a => new { a.AuthorId, a.BookId });
            x.HasOne(a => a.Book)
            .WithMany(a => a.Authors)
            .HasForeignKey(a => a.BookId);

            x.HasOne(a => a.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(a => a.AuthorId);
        });



    }
}
