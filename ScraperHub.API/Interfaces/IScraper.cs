namespace ScraperHub.API.Interfaces;

public interface IScraper<T>
{
    Task<List<T>> ScrapeAsync(string source);
}