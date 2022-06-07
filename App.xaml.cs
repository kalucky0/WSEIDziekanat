using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using WSEIDziekanat.Activation;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Core.Contracts.Services;
using WSEIDziekanat.Core.Services;
using WSEIDziekanat.Helpers;
using WSEIDziekanat.Models;
using WSEIDziekanat.Services;
using WSEIDziekanat.ViewModels;
using WSEIDziekanat.Views;

// To learn more about WinUI3, see: https://docs.microsoft.com/windows/apps/winui/winui3/.
namespace WSEIDziekanat;

public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsServicePackaged>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<ProfileDetailViewModel>();
            services.AddTransient<ProfileDetailPage>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<ProfilePage>();
            services.AddTransient<AnnouncementsViewModel>();
            services.AddTransient<AnnouncementsPage>();
            services.AddTransient<FinancesViewModel>();
            services.AddTransient<FinancesPage>();
            services.AddTransient<ScheduleDetailViewModel>();
            services.AddTransient<ScheduleDetailPage>();
            services.AddTransient<ScheduleViewModel>();
            services.AddTransient<SchedulePage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        })
        .Build();

    public static T GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };

    public App()
    {
        InitializeComponent();
        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // For more details, see https://docs.microsoft.com/windows/winui/api/microsoft.ui.xaml.unhandledexceptioneventargs.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        var activationService = App.GetService<IActivationService>();
        await activationService.ActivateAsync(args);
    }
}
