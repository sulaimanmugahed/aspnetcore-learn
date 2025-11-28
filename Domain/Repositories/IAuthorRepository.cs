namespace Domain;

public interface IAuthorRepository
{
    Author? GetDetail(int id);
    Task<Author?> GetDetailAsync(int id);
}
