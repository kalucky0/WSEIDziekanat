using System.Threading.Tasks;

namespace WSEIDziekanat.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
