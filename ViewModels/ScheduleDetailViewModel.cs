using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Core.Contracts.Services;
using WSEIDziekanat.Core.Models;

namespace WSEIDziekanat.ViewModels;

public class ScheduleDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;
    private SampleOrder _item;

    public SampleOrder Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public ScheduleDetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
