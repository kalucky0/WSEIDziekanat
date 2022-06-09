using System.Collections.Generic;
using System.Threading.Tasks;

namespace WSEIDziekanat.Contracts.Services;

public interface IGridDataService<T>
{
    Task<IEnumerable<T>> GetContentGridDataAsync();

    Task<IEnumerable<T>> GetGridDataAsync();
}