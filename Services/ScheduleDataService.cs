using System.Collections.Generic;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class ScheduleDataService : IDataService<IEnumerable<Schedule>>
{
    public IEnumerable<Schedule> GetData()
    {
        return new List<Schedule>();
    }
}