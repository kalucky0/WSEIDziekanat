using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Linq;
using System.Threading.Tasks;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services.Web;

public class StudentData : DataDownloader
{
    private const string UrlGeneral =
        @"https://dziekanat.wsei.edu.pl/TokStudiow/StudentTwojeDane/Osobowe";

    private const string UrlAddress =
        @"https://dziekanat.wsei.edu.pl/TokStudiow/StudentTwojeDane/Adresy";

    private const string UrlEducation =
        @"https://dziekanat.wsei.edu.pl/TokStudiow/StudentTwojeDane/Wyksztalcenie";

    public static async Task<Student> Get()
    {
        HtmlNode document = await GetData(UrlGeneral);

        string city = SelectVal(document, "Miasto");
        string maritalStatus = SelectVal(document, "StanCywilny");
        string nationality = SelectVal(document, "Narodowosc");
        string citizenship = SelectVal(document, "Obywatelstwo");

        HtmlNode[] personalData = document.QuerySelectorAll(".editable").ToArray();
        HtmlNode[] generalData = document.QuerySelectorAll("td.dane").ToArray();

        string index = document.QuerySelector("#td_naglowek table p")?.InnerHtml ?? "";

        document = await GetData(UrlAddress);

        HtmlNode[] addressData = document.QuerySelectorAll("span.sensitive").ToArray();
        string additional = document.QuerySelectorAll("td.dane").LastOrDefault()?.InnerText ?? "";

        document = await GetData(UrlEducation);

        HtmlNode[] educationData = document.QuerySelectorAll("td.dane").ToArray();

        return new Student(
            1,
            GetValue(personalData, 1),
            GetValue(personalData, 2),
            GetValue(personalData, 0),
            index.Split("szary'>")[1].Split("<")[0],
            index.Split("<br>")[2].Split("<br>")[0].Trim(),
            GetValue(personalData, 3),
            GetText(generalData, 11),
            city,
            GetValue(personalData, 5),
            GetText(generalData, 17),
            maritalStatus,
            nationality,
            citizenship,
            $"{GetValue(personalData, 9)} {GetValue(personalData, 10)}",
            GetValue(personalData, 11),
            GetValue(personalData, 12),
            GetValue(personalData, 13),
            GetValue(personalData, 14),
            GetValue(personalData, 15),
            GetValue(personalData, 16),
            GetValue(personalData, 17),
            GetValue(personalData, 18),
            GetValue(personalData, 19),
            GetText(addressData, 1),
            GetText(addressData, 2),
            GetText(addressData, 3),
            GetText(addressData, 4),
            GetText(addressData, 5),
            GetText(addressData, 6),
            GetText(addressData, 7),
            GetText(addressData, 9),
            GetText(addressData, 10),
            GetText(addressData, 11),
            GetText(addressData, 12),
            GetText(addressData, 13),
            additional,
            GetText(educationData, 1),
            GetText(educationData, 3),
            int.Parse(GetText(educationData, 5, "0")),
            $"{GetText(educationData, 7)},\n{GetText(educationData, 8)},\n{GetText(educationData, 9)}",
            GetText(educationData, 11),
            GetText(educationData, 13),
            GetText(educationData, 15),
            GetText(educationData, 17),
            GetText(educationData, 19),
            GetText(educationData, 21),
            GetText(educationData, 23),
            GetText(educationData, 25),
            GetText(educationData, 27)
        );
    }

    private static string SelectVal(HtmlNode doc, string id) =>
        doc.QuerySelector($"#{id} > option[selected]")?.InnerText ?? "";

    private static string GetValue(HtmlNode[] arr, int i) =>
        arr.Length <= i ? "" : arr[i].GetAttributeValue("value", "");

    private static string GetText(HtmlNode[] arr, int i, string def = "") =>
        arr.Length <= i ? def : arr[i].InnerText.Trim();
}