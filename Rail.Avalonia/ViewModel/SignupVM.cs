using Rail.Domain.Signup;

namespace Rail.Avalonia.ViewModel;

public sealed class Signup : BaseVM 
{
    private SignupService service;

    public Signup(SignupService ss) 
    {
        service = ss;
    }
    
}