using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreAuthorRepository(AppDbContext context) : EFCoreRepository<Author>(context), IAuthorRepository
{

    public Author? GetDetail(int id)
    {
        return context.Authors.Include(a => a.Books)
        .ThenInclude(c => c.Book)
        .FirstOrDefault(a => a.Id == id);
    }

   

    public async Task<Author?> GetDetailAsync(int id)
    {
        return await context.Authors.Include(a => a.Books)
   .ThenInclude(c => c.Book)
   .FirstOrDefaultAsync(a => a.Id == id);
    }


}
