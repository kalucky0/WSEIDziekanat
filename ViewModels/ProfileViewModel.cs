using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Contracts.ViewModels;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.ViewModels;

public class ProfileViewModel : ObservableRecipient, INavigationAware
{
    private readonly IDataService<Student> _profileDataService;

    public Student Source
    {
        get;
        private set;
    }

    public ProfileViewModel(IDataService<Student> dataService)
    {
        _profileDataService = dataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source = _profileDataService.GetData();
    }

    public void OnNavigatedFrom()
    {
    }
}