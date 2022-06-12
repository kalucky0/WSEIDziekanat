using System.Threading.Tasks;

namespace WSEIDziekanat.Contracts.Services;

public interface ISynchronizationService
{
    abstract Task<bool> Run();
}
