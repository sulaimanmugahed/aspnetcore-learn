using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreCustomerRepository(AppDbContext context) : EFCoreRepository<Customer>(context), ICustomerRepository
{


    public Customer? GetDetail(int id)
    {
        return context.Customers.FirstOrDefault(c => c.Id == id);
    }



    public List<Customer> GetAllDetail()
    {
        return context.Customers.ToList();
    }



}
