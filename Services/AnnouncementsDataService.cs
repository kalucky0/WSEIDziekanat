using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class AnnouncementsDataService : IGridDataService<Announcement>
{
    private List<Announcement> _announcement;

    private static IEnumerable<Announcement> AllAnnouncements() =>
        App.Database.Announcements.OrderBy(a => a.Date);

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