using Microsoft.AspNetCore.Mvc;
using ScraperHub.API.Interfaces;
using ScraperHub.API.Models;

namespace ScraperHub.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IScraper<Product> _scraper;

    public ProductController(IScraper<Product> scraper)
    {
        _scraper = scraper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        // Replace with actual test URL later
        var url = "https://example.com";

        var data = await _scraper.ScrapeAsync(url);

        return Ok(data);
    }
}