using System.Text.Json;
using ScraperHub.API.Models;

namespace ScraperHub.API.Services;

public class YouTubeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "AIzaSyCg7qKFO-IrazpPVfDD9VOzqjd789fJHro"; // replace

    public YouTubeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Video>> GetChannelVideos(string channelId)
    {
        var url =
            $"https://www.googleapis.com/youtube/v3/search?key={_apiKey}&channelId={channelId}&part=snippet&order=date&maxResults=10";

        var json = await _httpClient.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var videos = new List<Video>();

        foreach (var item in doc.RootElement.GetProperty("items").EnumerateArray())
        {
            var snippet = item.GetProperty("snippet");

            videos.Add(new Video
            {
                Title = snippet.GetProperty("title").GetString(),
                Channel = snippet.GetProperty("channelTitle").GetString(),
                PublishedAt = snippet.GetProperty("publishedAt").GetDateTime(),
                Url = $"https://www.youtube.com/watch?v={item.GetProperty("id").GetProperty("videoId").GetString()}"
            });
        }
        return videos;
    }
        public async Task<List<object>> SearchChannelsAsync(string query)
    {
        var url =
            $"https://www.googleapis.com/youtube/v3/search?key={_apiKey}&q={query}&type=channel&part=snippet&maxResults=5";

        var json = await _httpClient.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var results = new List<object>();

        foreach (var item in doc.RootElement.GetProperty("items").EnumerateArray())
        {
            var snippet = item.GetProperty("snippet");

            results.Add(new
            {
                ChannelName = snippet.GetProperty("title").GetString(),
                ChannelId = item.GetProperty("id").GetProperty("channelId").GetString(),
                Thumbnail = snippet.GetProperty("thumbnails").GetProperty("default").GetProperty("url").GetString(),
                Description = snippet.GetProperty("description").GetString()
            });
        }

        return results;
    }
}