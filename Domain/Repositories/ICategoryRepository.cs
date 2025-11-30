namespace Domain;

public interface ICategoryRepository:IRepository<Category>
{
    Category? GetDetail(int id);


}
