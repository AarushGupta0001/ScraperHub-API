using HtmlAgilityPack;
using ScraperHub.API.Interfaces;
using ScraperHub.API.Models;

namespace ScraperHub.API.Services;

public class ProductScraper : IScraper<Product>
{
    private readonly HttpClient _httpClient;

    public ProductScraper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> ScrapeAsync(string url)
    {
        var products = new List<Product>();

        var html = await _httpClient.GetStringAsync(url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Example selectors — will vary per site
        var nodes = doc.DocumentNode.SelectNodes("//div[contains(@class,'product')]");

        if (nodes == null)
            return products;

        foreach (var node in nodes)
        {
            var name = node.SelectSingleNode(".//h2")?.InnerText.Trim();
            var price = node.SelectSingleNode(".//span[contains(@class,'price')]")?.InnerText.Trim();

            products.Add(new Product
            {
                Name = name,
                Price = price,
                Url = url,
                Source = "Demo Store"
            });
        }

        return products;
    }
}