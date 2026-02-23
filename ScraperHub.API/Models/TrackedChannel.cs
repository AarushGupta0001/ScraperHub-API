namespace ScraperHub.API.Models;

public class TrackedChannel
{
    public int Id { get; set; }
    public string ChannelName { get; set; } = "";
    public string ChannelId { get; set; } = "";
    public DateTime AddedOn { get; set; } = DateTime.UtcNow;
}