using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreCategoryRepository(AppDbContext context) :EFCoreRepository<Category> (context),ICategoryRepository
{

    public Category? GetDetail(int id)
    {
        return context.Categories.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
    }



}
