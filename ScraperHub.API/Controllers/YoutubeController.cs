using Microsoft.AspNetCore.Mvc;
using ScraperHub.API.Services;

namespace ScraperHub.API.Controllers;

[ApiController]
[Route("api/youtube")]
public class YouTubeController : ControllerBase
{
    private readonly YouTubeService _youTubeService;

    public YouTubeController(YouTubeService youTubeService)
    {
        _youTubeService = youTubeService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchChannels([FromQuery] string query)
    {
        var results = await _youTubeService.SearchChannelsAsync(query);
        return Ok(results);
    }
}