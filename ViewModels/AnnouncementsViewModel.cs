using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.ViewModels;

public class AnnouncementsViewModel : ObservableRecipient, INavigationAware
{
    private readonly IGridDataService<Announcement> _announcementsDataService;

    public ObservableCollection<Announcement> Source { get; } = new();

    public AnnouncementsViewModel(IGridDataService<Announcement> dataService)
    {
        _announcementsDataService = dataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        var data = await _announcementsDataService.GetGridDataAsync();

        foreach (var item in data)
            Source.Add(item);
    }

    public void OnNavigatedFrom()
    {
    }
}
