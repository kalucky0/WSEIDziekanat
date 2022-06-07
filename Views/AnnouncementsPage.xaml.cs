using Microsoft.UI.Xaml.Controls;

using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
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
