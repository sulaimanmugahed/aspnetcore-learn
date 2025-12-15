using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Borrowing : Entity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CustomerId { get; set; }
    public int BookId { get; set; }
    public bool IsActive => DateTime.UtcNow > StartDate && DateTime.UtcNow < EndDate;
    public Book Book { get; set; }
    public Customer Customer { get; set; }
}
