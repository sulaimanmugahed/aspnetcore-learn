using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreCustomerRepository(AppDbContext context) : ICustomerRepository
{


    public Customer? GetDetail(int id)
    {
        return context.Customers.Include(a => a.User).FirstOrDefault(c => c.Id == id);
    }



    public List<Customer> GetAllDetail()
    {
        return context.Customers.Include(a => a.User).ToList();
    }



}
