namespace Domain;

public interface IUserRepository:IRepository<User>
{
    bool CheckPassword(int id, string password);
}
