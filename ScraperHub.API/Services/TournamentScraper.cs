using HtmlAgilityPack;
using ScraperHub.API.Interfaces;
using ScraperHub.API.Models;

namespace ScraperHub.API.Services;

public class TournamentScraper : IScraper<Tournament>
{
    private readonly HttpClient _httpClient;

    public TournamentScraper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Tournament>> ScrapeAsync(string url)
    {
        var tournaments = new List<Tournament>();

        var html = await _httpClient.GetStringAsync(url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Liquipedia tables often contain match data
        var rows = doc.DocumentNode.SelectNodes("//table[contains(@class,'wikitable')]//tr");

        if (rows == null)
            return tournaments;

        foreach (var row in rows.Skip(1)) // skip header
        {
            var cols = row.SelectNodes("td");
            if (cols == null || cols.Count < 3)
                continue;

            tournaments.Add(new Tournament
            {
                EventName = "PUBG Mobile Event",
                TeamA = cols[0].InnerText.Trim(),
                TeamB = cols[1].InnerText.Trim(),
                MatchTime = cols[2].InnerText.Trim(),
                Source = "Liquipedia"
            });
        }

        return tournaments;
    }
}