using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using WSEIDziekanat.Activation;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Helpers;
using WSEIDziekanat.Models;
using WSEIDziekanat.Services;
using WSEIDziekanat.ViewModels;
using WSEIDziekanat.Views;

namespace WSEIDziekanat;

public partial class App
{
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

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ISynchronizationService, SynchronizationService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IPageService, PageService>();

            // Core Services
            services.AddSingleton<IDataService<IEnumerable<Schedule>>, ScheduleDataService>();
            services.AddSingleton<IDataService<Student>, ProfileDataService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IGridDataService<Announcement>, AnnouncementsDataService>();
            services.AddSingleton<IGridDataService<Payment>, FinancesDataService>();

            // Views and ViewModels
            services.AddTransient<AnnouncementsPage>();
            services.AddTransient<AnnouncementsViewModel>();
            services.AddTransient<FinancesPage>();
            services.AddTransient<FinancesViewModel>();
            services.AddTransient<LoginPage>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ProfilePage>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<SchedulePage>();
            services.AddTransient<ScheduleViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        })
        .Build();

    public static T GetService<T>()
        where T : class => _host.Services.GetService(typeof(T)) as T;

    public static Window MainWindow { get; } = new() { Title = "AppDisplayName".GetLocalized() };

    public static DatabaseContext Database { get; set; }

    public static string SessionId = "";

    public App()
    {
        InitializeComponent();
        UnhandledException += App_UnhandledException;
    }

    private static void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
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