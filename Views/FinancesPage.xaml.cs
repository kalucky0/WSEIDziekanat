using Microsoft.UI.Xaml.Controls;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class FinancesPage : Page
{
    public FinancesViewModel ViewModel
    {
        get;
    }

    public FinancesPage()
    {
        ViewModel = App.GetService<FinancesViewModel>();
        InitializeComponent();
    }
}