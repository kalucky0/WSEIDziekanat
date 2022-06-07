using Microsoft.UI.Xaml.Controls;

using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class ProfilePage : Page
{
    public ProfileViewModel ViewModel
    {
        get;
    }

    public ProfilePage()
    {
        ViewModel = App.GetService<ProfileViewModel>();
        InitializeComponent();
    }
}
