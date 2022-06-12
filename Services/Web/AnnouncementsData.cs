using Fizzler.Systems.HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services.Web;

public class AnnouncementsData : DataDownloader
{
    private const string Url =
        @"https://dziekanat.wsei.edu.pl/TokStudiow/StudentOgloszenia/Ogloszenia";

    public static async Task<List<Announcement>> Get() =>
        (from row in (await GetData(Url))
                .QuerySelectorAll("table.dane tbody tr")
         let data = row.QuerySelectorAll("td").Select(x => x.InnerText.Trim()).ToList()
         let uid = int.Parse(row.QuerySelector("a").Attributes["href"].Value.Split("/").Last())
         select new Announcement(uid,
             data[2],
             data[1],
             data[3],
             row.Attributes["style"].Value.Contains("normal")
         )
        ).ToList();
}