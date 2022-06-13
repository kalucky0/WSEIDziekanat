using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            App.Database.Students.RemoveRange(App.Database.Students);

            await App.Database.Students.AddAsync(student);

            await App.Database.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Debug.Fail(e.Message, e.StackTrace);
            return false;
        }
    }

    private async Task<bool> TryGetSchedule()
    {
        try
        {
            List<Schedule> schedule = await ScheduleData.Get();

            App.Database.Schedule.RemoveRange(App.Database.Schedule);

            await App.Database.Schedule.AddRangeAsync(schedule);

            await App.Database.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Debug.Fail(e.Message, e.StackTrace);
            return false;
        }
    }

    private async Task<bool> TryGetAnnouncements()
    {
        try
        {
            List<Announcement> announcements = await AnnouncementsData.Get();
            App.Database.Announcements.RemoveRange(App.Database.Announcements);

            await App.Database.Announcements.AddRangeAsync(announcements);

            await App.Database.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Debug.Fail(e.Message, e.StackTrace);
            return false;
        }
    }

    private async Task<bool> TryGetPayments()
    {
        try
        {
            List<Payment> payments = await PaymentsData.Get();
            App.Database.Payments.RemoveRange(App.Database.Payments);

            await App.Database.Payments.AddRangeAsync(payments);

            await App.Database.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Debug.Fail(e.Message, e.StackTrace);
            return false;
        }
    }

    private async Task<bool> TryGetGrades()
    {
        // TODO: Add grades

        return true;
    }
}
