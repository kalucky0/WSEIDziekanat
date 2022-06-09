using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.ViewModels;

public class FinancesViewModel : ObservableRecipient, INavigationAware
{
    private readonly IGridDataService<Payment> _financesDataService;

    public ObservableCollection<Payment> Source { get; } = new();

    public FinancesViewModel(IGridDataService<Payment> dataService)
    {
        _financesDataService = dataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        var data = await _financesDataService.GetGridDataAsync();

        foreach (var item in data)
            Source.Add(item);
    }

    public void OnNavigatedFrom()
    {
    }
}
