﻿using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class ProfileDetailPage : Page
{
    public ProfileDetailViewModel ViewModel
    {
        get;
    }

    public ProfileDetailPage()
    {
        ViewModel = App.GetService<ProfileDetailViewModel>();
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();
            navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
        }
    }
}
