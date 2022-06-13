using System.Threading.Tasks;

namespace WSEIDziekanat.Contracts.Services;

internal interface IAuthenticationService
{
    Task<string?> TryLogin(string login, string password, string[] formFields);
    Task<string?> GetLoginPage();
}
