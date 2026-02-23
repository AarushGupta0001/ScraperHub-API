using Microsoft.AspNetCore.Mvc;
using ScraperHub.API.Interfaces;
using ScraperHub.API.Models;

namespace ScraperHub.API.Controllers;

[ApiController]
[Route("api/tournaments")]
public class TournamentController : ControllerBase
{
    private readonly IScraper<Tournament> _scraper;

    public TournamentController(IScraper<Tournament> scraper)
    {
        _scraper = scraper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTournaments()
    {
        var url = "https://liquipedia.net/pubgmobile/Main_Page";

        var data = await _scraper.ScrapeAsync(url);

        return Ok(data);
    }
}