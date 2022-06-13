using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class LoginPage : Page
{
    public LoginViewModel ViewModel { get; }

    public LoginPage()
    {
        ViewModel = App.GetService<LoginViewModel>();
        InitializeComponent();
    }

    private void loginBox_LoginChanged(object sender, TextChangedEventArgs e) =>
        ViewModel.Login = LoginBox.Text;

    private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e) =>
        ViewModel.Password = PasswordBox.Password;


    private async void loginButton_Click(object sender, RoutedEventArgs e)
    {
        LoginBox.IsEnabled = false;
        PasswordBox.IsEnabled = false;
        LoginButton.IsEnabled = false;
        await ViewModel.Authenticate();
        LoginBox.IsEnabled = true;
        PasswordBox.IsEnabled = true;
        LoginButton.IsEnabled = true;
    }
}