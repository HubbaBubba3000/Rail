using Rail.Domain.Abstractions;
namespace Rail.Domain.Signup;

public class SignupService 
{
    private readonly IUserRepository Users;

    public SignupService(IUserRepository ur)
    {
        Users = ur;
    }
    public void Signup(IUser NewUser)
    {
        //check validation (email, password, name)
        //create user in db
        
        Users.CreateUser(NewUser);
    }
}