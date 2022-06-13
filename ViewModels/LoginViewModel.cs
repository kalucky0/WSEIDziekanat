using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.ViewModels;

public class LoginViewModel : ObservableRecipient
{
    public string Login { get; set; }
    public string Password { get; set; }

    private readonly IAuthenticationService _authenticationService;
    private readonly ISynchronizationService _synchronizationService;
    private readonly INavigationService _navigationService;
    private List<string> _formFields = new();

    public LoginViewModel()
    {
        _authenticationService = App.GetService<IAuthenticationService>();
        _synchronizationService = App.GetService<ISynchronizationService>();
        _navigationService = App.GetService<INavigationService>();
        Initialize();
    }

    private async Task Initialize() =>
        _formFields = await GetFormFields();

    private async Task<bool> ValidateFields()
    {
        if (Login is null || Login.Length < 3 || !Login.Contains('.'))
        {
            await ShowSnackbar("Błędny login");
            return false;
        }

        if (Password is null || Password.Length < 3)
        {
            await ShowSnackbar("Błędne hasło");
            return false;
        }

        return true;
    }

    private async Task<List<string>> GetFormFields()
    {
        var data = await _authenticationService.GetLoginPage() ?? "";
        if (data.Length == 0)
            return new();

        if (data.Contains("wpisz kod z obrazka"))
            await _authenticationService.SolveCaptcha();

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

    public async Task Authenticate()
    {
        if (!await ValidateFields())
            return;

        var login = HttpUtility.UrlEncode(Login);
        var password = HttpUtility.UrlEncode(Password);

        var data = await _authenticationService.TryLogin(login, password, _formFields.ToArray()) ?? "";

        data = "/Konto/Zdjecie/";
        App.SessionId = "5nop5nllbmyadl1yo1vtwe35";

        if (data.Contains("/Konto/Zdjecie/"))
        {
            await App.Database.AddAsync(new Credentials(0, Login, Password));
            await App.Database.SaveChangesAsync();

            if (await _synchronizationService.Run())
                _navigationService.GoBack();
            else
                await ShowSnackbar("Błąd synchronizacji danych!");
        }
        else
        {
            await ShowSnackbar("Błąd logowania!");
        }
    }

    private async Task ShowSnackbar(string text)
    {
        // TODO: Show an alert
        Debug.WriteLine(text);
    }
}