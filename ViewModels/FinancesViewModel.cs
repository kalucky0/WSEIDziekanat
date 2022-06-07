using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Core.Contracts.Services;
using WSEIDziekanat.Core.Models;

namespace WSEIDziekanat.ViewModels;

public class FinancesViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public FinancesViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
