using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;
using WSEIDziekanat.Services.Web;

namespace WSEIDziekanat.Services;

public class SynchronizationService : ISynchronizationService
{
    public async Task<bool> Run()
    {
        return await TryGetStudent() &&
               await TryGetSchedule() &&
               await TryGetAnnouncements() &&
               await TryGetPayments() &&
               await TryGetGrades();
    }

    private async Task<bool> TryGetStudent()
    {
        try
        {
            Student student = await StudentData.Get();
            // TODO: Save student to database
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> TryGetSchedule()
    {
        try
        {
            List<Schedule> schedule = await ScheduleData.Get();
            // TODO: Save schedule to database
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> TryGetAnnouncements()
    {
        try
        {
            List<Announcement> announcements = await AnnouncementsData.Get();
            // TODO: Save announcements to database
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> TryGetPayments()
    {
        try
        {
            List<Payment> payments = await PaymentsData.Get();
            // TODO: Save payments to database
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> TryGetGrades()
    {
        // TODO: Add grades
        return true;
    }
}
