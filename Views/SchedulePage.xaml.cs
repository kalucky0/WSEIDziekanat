using System;
using System.Linq;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using WSEIDziekanat.ViewModels;

namespace WSEIDziekanat.Views;

public sealed partial class SchedulePage : Page
{
    public ScheduleViewModel ViewModel { get; }

    public SchedulePage()
    {
        ViewModel = App.GetService<ScheduleViewModel>();
        InitializeComponent();

        ScheduleItems.VerticalAlignment = VerticalAlignment.Top;

        var schedule = App.Database.Schedule.OrderBy(e => e.Day);

        foreach (var item in schedule)
        {
            var date = DateTime.Parse(item.Day);
            var day = (int)date.DayOfWeek;
            var scheduleItem = ScheduleItem(item.Subject, item.Instructor, item.Location, item.Type, day, item.TimeFrom, item.TimeTo);
            ScheduleItems.Children.Add(scheduleItem);
        }

        HighlightToday();
    }

    private void HighlightToday()
    {
        var today = DateTime.Today;
        var todayIndex = (int)today.DayOfWeek;
        var color = new SolidColorBrush(Color.FromArgb(255, 0, 183, 195));

        switch (todayIndex)
        {
            case 0:
                MondayText.FontWeight = FontWeights.SemiBold;
                MondayBorder.BorderThickness = new Thickness(0, 0, 0, 2);
                MondayBorder.BorderBrush = color;
                break;
            case 1:
                TuesdayText.FontWeight = FontWeights.SemiBold;
                TuesdayBorder.BorderThickness = new Thickness(0, 0, 0, 2);
                TuesdayBorder.BorderBrush = color;
                break;
            case 2:
                WednesdayText.FontWeight = FontWeights.SemiBold;
                WednesdayBorder.BorderThickness = new Thickness(0, 0, 0, 2);
                WednesdayBorder.BorderBrush = color;
                break;
            case 3:
                ThursdayText.FontWeight = FontWeights.SemiBold;
                ThursdayBorder.BorderThickness = new Thickness(0, 0, 0, 2);
                ThursdayBorder.BorderBrush = color;
                break;
            case 4:
                FridayText.FontWeight = FontWeights.SemiBold;
                FridayBorder.BorderThickness = new Thickness(0, 0, 0, 2);
                FridayBorder.BorderBrush = color;
                break;
        }
    }

    private Grid ScheduleItem(string subject, string teacher, string location, string type, int day, double timeFrom,
        double timeTo)
    {
        TextBlock subjectBlock = new TextBlock
        {
            Text = subject,
            FontSize = 13,
            FontWeight = FontWeights.Bold,
            VerticalAlignment = VerticalAlignment.Top,
        };

        TextBlock hourBlock = new TextBlock
        {
            Text = $"{ParseHour(timeFrom)} - {ParseHour(timeTo)}",
            FontSize = 12,
            FontWeight = FontWeights.Normal,
            Margin = new Thickness(0, 0, 0, 16),
            VerticalAlignment = VerticalAlignment.Bottom,
        };

        TextBlock infoBlock = new TextBlock
        {
            Text = $"{teacher} • {location} • {type}",
            FontSize = 11,
            FontWeight = FontWeights.Normal,
            VerticalAlignment = VerticalAlignment.Bottom,
        };

        timeFrom -= 8f;
        timeTo -= 8f;

        Grid scheduleItem = new Grid
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32)),
            Padding = new Thickness(6),
            CornerRadius = new CornerRadius(4),
            Margin = new Thickness(4, timeFrom * 64, 2, 0),
            Height = (timeTo - timeFrom) * 64,
        };

        scheduleItem.Children.Add(subjectBlock);
        scheduleItem.Children.Add(hourBlock);
        scheduleItem.Children.Add(infoBlock);

        Grid.SetColumn(scheduleItem, day + 1);
        Grid.SetRow(scheduleItem, 1);

        return scheduleItem;
    }

    private string ParseHour(double time)
    {
        int hour = (int)time;
        int minute = (int)((time - hour) * 60);
        return $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}";
    }
}