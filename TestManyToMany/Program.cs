using Microsoft.EntityFrameworkCore;
using TestManyToMany.Domain;
using TestManyToMany.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (ApplicationDbContext context) =>
    {
        var forecasts = await context.TariffBuilders.ToArrayAsync();
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    //.WithOpenApi()
    ;

app.MapPost("/tariffbuilder", async (ApplicationDbContext context, TariffBuilder tariff) =>
    {
        context.TariffBuilders.Add(tariff);
        await context.SaveChangesAsync();
        return Results.Created($"/weatherforecast", tariff);
    })
    .WithName("CreateTariffBuilder")
    //.WithOpenApi()
    ;

app.MapDelete("/tariffbuilder/{id}", async (ApplicationDbContext context, int id) =>
    {
        var tariff = await context.TariffBuilders.FindAsync(id);
        if (tariff is not null)
        {
            context.TariffBuilders.Remove(tariff);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
        return Results.NotFound();
    })
    .WithName("DeleteTariffBuilder")
    //.WithOpenApi()
    ;

app.MapPost("/tariffbuilderconcept", async (ApplicationDbContext context, TariffBuilderRateConcept concept) =>
    {
        context.TariffBuilderRateConcepts.Add(concept);
        await context.SaveChangesAsync();
        return Results.Created($"/weatherforecast", concept);
    })
    .WithName("CreateTariffBuilderRateConcept")
    //.WithOpenApi()
    ;

app.MapDelete("/tariffbuilderconcept/{id}", async (ApplicationDbContext context, int id) =>
    {
        var concept = await context.TariffBuilderRateConcepts.FindAsync(id);
        if (concept is not null)
        {
            context.TariffBuilderRateConcepts.Remove(concept);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
        return Results.NotFound();
    })
    .WithName("DeleteTariffBuilderRateConcept")
    //.WithOpenApi()
    ;

app.MapPost("/tariffbuilderrate", async (ApplicationDbContext context, TariffBuilderRate rate) =>
    {
        context.TariffBuilderRates.Add(rate);
        await context.SaveChangesAsync();
        return Results.Created($"/weatherforecast", rate);
    })
    .WithName("CreateTariffBuilderRate")
    //.WithOpenApi()
    ;

app.MapDelete("/tariffbuilderrate/{id}", async (ApplicationDbContext context, int id) =>
    {
        var rate = await context.TariffBuilderRates.FindAsync(id);
        if (rate is not null)
        {
            context.TariffBuilderRates.Remove(rate);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }
        return Results.NotFound();
    })
    .WithName("DeleteTariffBuilderRate")
    //.WithOpenApi()
    ;

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}