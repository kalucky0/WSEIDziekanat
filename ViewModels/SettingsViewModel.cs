using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;

using Windows.ApplicationModel;

using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Helpers;

namespace WSEIDziekanat.ViewModels;

public class SettingsViewModel : ObservableRecipient
{
    private readonly IThemeSelectorService _themeSelectorService;
    private ElementTheme _elementTheme;

    public ElementTheme ElementTheme
    {
        get => _elementTheme;
        set => SetProperty(ref _elementTheme, value);
    }

    private string _versionDescription;

    public string VersionDescription
    {
        get => _versionDescription;
        set => SetProperty(ref _versionDescription, value);
    }

    private ICommand _switchThemeCommand;

    public ICommand SwitchThemeCommand
    {
        get
        {
            if (_switchThemeCommand == null)
            {
                _switchThemeCommand = new RelayCommand<ElementTheme>(
                    async (param) =>
                    {
                        if (ElementTheme != param)
                        {
                            ElementTheme = param;
                            await _themeSelectorService.SetThemeAsync(param);
                        }
                    });
            }

            return _switchThemeCommand;
        }
    }
    
    private async Task<List<string>> GetFormFields(IAuthenticationService authenticationService)
    {
        var data = await authenticationService.GetLoginPage() ?? "";
        if (data.Length == 0)
            return new();

        if (data.Contains("wpisz kod z obrazka"))
            await authenticationService.SolveCaptcha();

        var regex = new Regex(
            "<tr style=\"(.*?)\">.+?formularz_dane\">\\s+<input.+?name=\"([0-9A-f]+)\".+?type=\"([a-z]+)\"",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        var matches = regex.Matches(data).ToArray();

        Debug.WriteLine("GetFormFields: " + matches.Length);

        return matches
            .Select(it => it.Groups[2].Value)
            .Where(it => it != "2442")
            .ToList();
    }

    public async Task Synchronize(string login, string password)
    {
        var authenticationService = App.GetService<IAuthenticationService>();
        var synchronizationService = App.GetService<ISynchronizationService>();

        var fields = await GetFormFields(authenticationService);
        var data = await authenticationService.TryLogin(login, password, fields.ToArray()) ?? "";

        if (data.Contains("/Konto/Zdjecie/"))
        {
            if (await synchronizationService.Run())
            {
                // TODO: Show success message
            }
            else
            {
                // TODO: Show error message
                Debug.Fail("Synchronization failed");
            }

        }
        else
        {
            // TODO: Show error message
            Debug.Fail("Failed to log in");
        }
    }    

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
        VersionDescription = GetVersionDescription();
    }

    private static string GetVersionDescription()
    {
        var appName = "AppDisplayName".GetLocalized();
        var version = Package.Current.Id.Version;

        return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}
