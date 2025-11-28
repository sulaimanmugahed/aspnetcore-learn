namespace Domain;

public interface ICustomerRepository
{



    Customer? GetDetail(int id);
    List<Customer> GetAllDetail();



}
