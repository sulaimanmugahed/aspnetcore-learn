namespace Domain;

public interface IUserRepository
{
    bool CheckPassword(int id, string password);
}
