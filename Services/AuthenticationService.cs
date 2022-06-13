using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Services.Web;

namespace WSEIDziekanat.Services;

internal class AuthenticationService : DataDownloader, IAuthenticationService
{
    public static string captchaCode = "";

    private const string UrlLogin = "https://dziekanat.wsei.edu.pl/Konto/LogowanieStudenta";

    public Task SolveCaptcha()
    {
        // TODO: Handle captcha
        return Task.CompletedTask;
    }

    public async Task<string?> TryLogin(string login, string password, string[] formFields)
    {
        var credentials = captchaCode.Length == 0
            ? $"{formFields[0]}={login}&{formFields[1]}={password}"
            : $"{formFields[0]}={login}&{formFields[1]}={password}&captcha={captchaCode}";

        var headers = new Dictionary<string, string>()
        {
            { "User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0" },
            { "Cookie", $"ASP.NET_SessionId={App.SessionId}" },
            { "Content-Type", "application/x-www-form-urlencoded" },
        };

        var client = new RestClient();

        var request = new RestRequest(UrlLogin, method: Method.Post);
        request.AddBody(credentials);
        request.AddHeaders(headers);

        var cancellationTokenSource = new CancellationTokenSource();

        RestResponse response = await client.ExecutePostAsync(request, cancellationTokenSource.Token);

        return response.IsSuccessful ? response.Content : null;
    }

    public async Task<string?> GetLoginPage()
    {
        var client = new RestClient();
        var request = new RestRequest(UrlLogin, method: Method.Get);
        request.AddHeader("user-agent",
            "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
        var cancellationTokenSource = new CancellationTokenSource();

        RestResponse response = await client.ExecuteGetAsync(request, cancellationTokenSource.Token);

        if (!response.IsSuccessful || response.Headers is null) return null;
        
        var sessionIdRegex = new Regex(@"ASP.NET_SessionId=(.*?);");
        App.SessionId = sessionIdRegex.Match(response.Headers.ToList()
            .Find(x => x.Name?.ToLower() == "set-cookie")?
            .Value?.ToString() ?? string.Empty).Groups[1].Value;

        return response.Content;
    }
}