namespace Domain;

public interface IAuthorRepository : IRepository<Author>
{
    Author? GetDetail(int id);
    Task<Author?> GetDetailAsync(int id);
}
