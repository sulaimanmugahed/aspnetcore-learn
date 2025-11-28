using Domain;


namespace Data;

public class EFCoreUserRepository(AppDbContext context) : IUserRepository
{

    public bool CheckPassword(int id, string password)
    {
        var user = context.Users.FirstOrDefault(a => a.Id == id);
        return user is not null && user.Password != password;
    }


}
