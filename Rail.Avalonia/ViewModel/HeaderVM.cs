using Rail.Domain.Abstractions;
using System;
namespace Rail.Avalonia.ViewModel;

public sealed class HeaderVM : BaseVM
{
    readonly IUserRepository User;

    public HeaderVM(IUserRepository userrep)
    {
        User = userrep;
    }

    public string UserName 
    {
        get {
            var n = User.GetUser("bababoe@mail.cum");
            Console.WriteLine(n);
            return n.Name;
        }
        set 
        {
            OnPropertyChanged();
        }
    }

}