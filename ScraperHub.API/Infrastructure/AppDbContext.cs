using Microsoft.EntityFrameworkCore;
using ScraperHub.API.Models;

namespace ScraperHub.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TrackedChannel> TrackedChannels => Set<TrackedChannel>();
}