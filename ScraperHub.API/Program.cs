using ScraperHub.API.Interfaces;
using ScraperHub.API.Models;
using ScraperHub.API.Services;
using ScraperHub.API.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace ScraperHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IScraper<Product>, ProductScraper>();
            builder.Services.AddScoped<IScraper<Tournament>, TournamentScraper>();
            builder.Services.AddHttpClient<TournamentScraper>();
            builder.Services.AddScoped<YouTubeService>();
            builder.Services.AddHttpClient<ProductScraper>();
            builder.Services.AddHttpClient<YouTubeService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
