using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreAuthorRepository(AppDbContext context) : IAuthorRepository
{

    public Author? GetDetail(int id)
    {
        return context.Authors.Include(a => a.Books)
        .ThenInclude(c => c.Book)
        .FirstOrDefault(a => a.Id == id);
    }


    public async Task<List<Author>> GetAllAsync()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author?> GetAsync(int id)
    {
        return await context.Authors.FindAsync(id);

    }

    public async Task DeleteAsync(int id)
    {
        var a = await context.Authors.FindAsync(id);
        if (a is not null)
        {
            context.Authors.Remove(a);
          await  context.SaveChangesAsync();

        }
    }

    public async Task<Author?> GetDetailAsync(int id)
    {
        return await context.Authors.Include(a => a.Books)
   .ThenInclude(c => c.Book)
   .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task CreateAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();
    }
}
