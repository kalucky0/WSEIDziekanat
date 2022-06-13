using Microsoft.UI.Xaml.Controls;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class LoginPage : Page
{
    public LoginViewModel ViewModel
    {
        get;
    }

    public LoginPage()
    {
        ViewModel = App.GetService<LoginViewModel>();
        InitializeComponent();
    }
}
