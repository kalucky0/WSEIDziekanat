using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Core.Contracts.Services;
using WSEIDziekanat.Core.Models;

namespace WSEIDziekanat.ViewModels;

public class ProfileViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly ISampleDataService _sampleDataService;
    private ICommand _itemClickCommand;

    public ICommand ItemClickCommand => _itemClickCommand ??= new RelayCommand<SampleOrder>(OnItemClick);

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public ProfileViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
    {
        _navigationService = navigationService;
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetContentGridDataAsync();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    private void OnItemClick(SampleOrder clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ProfileDetailViewModel).FullName, clickedItem.OrderID);
        }
    }
}
