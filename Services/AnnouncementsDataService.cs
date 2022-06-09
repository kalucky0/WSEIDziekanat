using System.Collections.Generic;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class AnnouncementsDataService : IGridDataService<Announcement>
{
    private List<Announcement> _announcement;

    private static IEnumerable<Announcement> AllAnnouncements()
    {
        return new List<Announcement>
        {
            new(0,
                "Konkurs WSEI Elevator Pitch 2022_DemoDay_15.06.2022",
                "Wysoki",
                "2022-06-09",
                false
            ),
            new(0,
                "Pytania do obrony - ZARZĄDZANIE 2022",
                "Średni",
                "2022-06-09",
                true
            ),
        };
    }

    public async Task<IEnumerable<Announcement>> GetContentGridDataAsync()
    {
        if (_announcement == null)
            _announcement = new List<Announcement>(AllAnnouncements());

        await Task.CompletedTask;
        return _announcement;
    }

    public async Task<IEnumerable<Announcement>> GetGridDataAsync()
    {
        if (_announcement == null)
            _announcement = new List<Announcement>(AllAnnouncements());

        await Task.CompletedTask;
        return _announcement;
    }
}