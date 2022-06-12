using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services.Web;

public class ScheduleData : DataDownloader
{
    private const string Url =
        @"https://dziekanat.wsei.edu.pl/Plany/PlanyStudentow";

    public static async Task<List<Schedule>> Get()
    {
        var schedule = new List<Schedule>();

        HtmlNode document = await GetData(Url);
        HtmlNode[] rows = document.QuerySelectorAll(".dxgvDataRow_Aqua,.dxgvGroupRow_Aqua").Reverse().ToArray();
        var date = "";
        var i = 0;

        foreach (HtmlNode row in rows)
        {
            if (row.InnerText.Contains("Data Zajęć"))
                date = FindDate(row.InnerText.Trim());
            else
            {
                HtmlNode[] cols = row.QuerySelectorAll("td").ToArray();
                schedule.Add(new Schedule(
                    i,
                    date,
                    ParseHour(cols[1].InnerText),
                    ParseHour(cols[2].InnerText),
                    cols[5].InnerText.Replace("&nbsp", ""),
                    cols[4].InnerText.Replace("&nbsp", ""),
                    cols[6].InnerText,
                    cols[7].InnerText,
                    cols[8].InnerText.Replace("&nbsp", "")
                ));
                i++;
            }
        }

        return schedule;
    }

    private static string FindDate(string text)
    {
        var regex = new Regex(@"....-..-..");
        return regex.Match(text).Groups[0].Value;
    }

    private static double ParseHour(string t)
    {
        string[] time = t.Split(':');
        int hour = int.Parse(time[0]);
        double minutes = double.Parse(time[1]) / 60.0;
        return hour + minutes;
    }
}