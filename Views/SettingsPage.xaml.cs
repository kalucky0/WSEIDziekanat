using System.Diagnostics;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
    }

    private async void syncButton_Click(object sender, RoutedEventArgs e)
    {
        SyncButton.Content = "Synchronizowanie...";
        SyncButton.IsEnabled = false;
        var credentials = App.Database.Credentials.First();
        Debug.WriteLine($"{credentials.Login} {credentials.Password}");
        await ViewModel.Synchronize(credentials.Login, credentials.Password);
        SyncButton.IsEnabled = true;
        SyncButton.Content = "Synchronizuj";
    }
}
