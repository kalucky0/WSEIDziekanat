using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WSEIDziekanat.Services.Web;

public class DataDownloader
{
    private static Dictionary<string, string> Headers =>
        new()
        {
            { "User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0" },
            { "Cookie", "ASP.NET_SessionId=" },
        };

    protected static async Task<HtmlNode> GetData(string url)
    {
        var client = new RestClient();
        var cancellationTokenSource = new CancellationTokenSource();

        var request = new RestRequest(url);
        request.AddHeaders(Headers);
        RestResponse response = await client.ExecuteGetAsync(request, cancellationTokenSource.Token);

        if (!response.IsSuccessful) throw new Exception("Failed to load student data");

        var html = new HtmlDocument();
        html.LoadHtml(response.Content);
        return html.DocumentNode;
    }
}
