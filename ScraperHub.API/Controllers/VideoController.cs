using Microsoft.AspNetCore.Mvc;
using ScraperHub.API.Services;

namespace ScraperHub.API.Controllers;

[ApiController]
[Route("api/videos")]
public class VideoController : ControllerBase
{
    private readonly YouTubeService _youTubeService;

    public VideoController(YouTubeService youTubeService)
    {
        _youTubeService = youTubeService;
    }

    [HttpGet("{channelId}")]
    public async Task<IActionResult> GetVideos(string channelId)
    {
        var videos = await _youTubeService.GetChannelVideos(channelId);
        return Ok(videos);
    }
}