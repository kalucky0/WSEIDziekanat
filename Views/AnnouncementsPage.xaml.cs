using Microsoft.UI.Xaml.Controls;

using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class AnnouncementsPage : Page
{
    public AnnouncementsViewModel ViewModel
    {
        get;
    }

    public AnnouncementsPage()
    {
        ViewModel = App.GetService<AnnouncementsViewModel>();
        InitializeComponent();
    }
}
