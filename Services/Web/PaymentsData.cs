using Fizzler.Systems.HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services.Web;

public class PaymentsData : DataDownloader
{
    private const string Url =
        @"https://dziekanat.wsei.edu.pl/Finanse/StudentFinanse/Oplaty";

    public static async Task<List<Payment>> Get() =>
        (await GetData(Url))
        .QuerySelectorAll(".dxgvDataRow_Aqua")
        .Select(row => row.QuerySelectorAll("td").ToList()
            .Select(td => td.InnerText.Trim()).ToArray())
        .Select((data, i) => new Payment(
            i,
            data[1],
            data[2],
            data[3],
            data[4].Split(" ")[0],
            data[5].Split(" ")[0],
            data[6],
            data[7].Replace("&nbsp;", " ")
                .Replace("PLN", "PLN\n"))
        ).ToList();
}