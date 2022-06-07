using System.Threading.Tasks;

namespace WSEIDziekanat.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}
