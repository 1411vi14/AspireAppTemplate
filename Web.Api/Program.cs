using AspireAppTemplate.ServiceDefaults;

using Scalar.AspNetCore;

using Web.Api.Application.Options;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddOptions<BaseOptions>(BaseOptions.Section);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
#if DEBUG
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
	options.Title = "Brickcity Story Management API";
	options.ShowSidebar = true;
});
app.UseDeveloperExceptionPage();
#endif


app.UseHttpsRedirection();

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

#pragma warning disable CA5394
app.MapGet("/weatherforecast", () =>
	{
		WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
				new WeatherForecast
				(
					DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					Random.Shared.Next(-20, 55),
					summaries[Random.Shared.Next(summaries.Length)]
				))
			.ToArray();
		return forecast;
	})
	.WithName("GetWeatherForecast");
#pragma warning restore CA5394

await app.RunAsync(app.Lifetime.ApplicationStopping);

sealed record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}