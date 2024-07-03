using Rail.Domain.Abstractions;
namespace Rail.Domain.Login;

public class LoginService 
{
    private readonly IUserRepository Users;

    public LoginService(IUserRepository ur)
    {
        Users = ur;
    }
    public void Login(IUser user)
    {
        //check validation (check email and password)
        //if user is exist direct to home page 
        
    }
    
}
