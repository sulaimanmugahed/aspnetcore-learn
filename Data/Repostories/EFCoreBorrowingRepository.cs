using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repostories;

public class EFCoreBorrowingRepository(AppDbContext context) : EFCoreRepository<Borrowing>(context), IBorrowingRepository
{
    public List<Borrowing> GetAllActive()
    {
        return context.Borrowings.Where(a => a.IsActive).ToList();
    }

    public Borrowing? GetDetail(int id)
    {
        return context.Borrowings.Include(a => a.Book).Include(x => x.Customer).FirstOrDefault(a => a.Id == id);
    }
}
