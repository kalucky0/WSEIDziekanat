using System.Collections.Generic;
using System.Linq;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class ScheduleDataService : IDataService<IEnumerable<Schedule>>
{
    public IEnumerable<Schedule> GetData() =>
        App.Database.Schedule.OrderBy(a => a.Id);
}