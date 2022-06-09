using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.ViewModels;

public class ScheduleViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDataService<IEnumerable<Schedule>> _scheduleDataService;

    public ObservableCollection<Schedule> Source
    {
        get;
        private set;
    }

    public ScheduleViewModel(IDataService<IEnumerable<Schedule>> dataService)
    {
        _scheduleDataService = dataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source = new ObservableCollection<Schedule>(_scheduleDataService.GetData());
    }

    public void OnNavigatedFrom()
    {
    }
}