using Rail.Avalonia.Model;

using System;
namespace Rail.Avalonia.ViewModel;

public sealed class HeaderVM : BaseVM
{
    readonly UserContext Context;

    public HeaderVM(UserContext uc)
    {
        Context = uc;
    }

    public string UserName 
    {
        get {
            return Context.User.Name;
        }
        set 
        {
            OnPropertyChanged();
        }
    }
    public int Level 
    {
        get {
            return Context.User.Level;
        }
        set 
        {
            OnPropertyChanged();
        }
    }

}