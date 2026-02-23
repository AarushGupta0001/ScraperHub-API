using Microsoft.AspNetCore.Mvc;
using ScraperHub.API.Infrastructure;
using ScraperHub.API.Models;

namespace ScraperHub.API.Controllers;

[ApiController]
[Route("api/channels")]
public class ChannelController : ControllerBase
{
    private readonly AppDbContext _context;

    public ChannelController(AppDbContext context)
    {
        _context = context;
    }

    // 🔹 Save a channel
    [HttpPost]
    public async Task<IActionResult> AddChannel(TrackedChannel channel)
    {
        _context.TrackedChannels.Add(channel);
        await _context.SaveChangesAsync();

        return Ok(channel);
    }

    // 🔹 Get all tracked channels
    [HttpGet]
    public IActionResult GetChannels()
    {
        return Ok(_context.TrackedChannels.ToList());
    }
}