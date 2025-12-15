using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories;

public interface IBorrowingRepository : IRepository<Borrowing>
{
    Borrowing? GetDetail(int id);
    List<Borrowing> GetAllActive();

}
