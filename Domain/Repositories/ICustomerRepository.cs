namespace Domain;

public interface ICustomerRepository:IRepository<Customer>
{



    Customer? GetDetail(int id);
    List<Customer> GetAllDetail();



}
