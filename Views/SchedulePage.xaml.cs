using Microsoft.UI.Xaml.Controls;

using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class SchedulePage : Page
{
    public ScheduleViewModel ViewModel
    {
        get;
    }

    public SchedulePage()
    {
        ViewModel = App.GetService<ScheduleViewModel>();
        InitializeComponent();
    }
}
