using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;

var builder = WebApplication.CreateBuilder(args);

const string devCorsPolicy = "devCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: devCorsPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors(devCorsPolicy);
}

app.MapGet("", () =>
{
    Results.Redirect("http://localhost:5173/");
});

Spotify spotify = new Spotify();

SpotifyEndpoints.MapEndpoints(app, spotify);
SpotifyAuthEndpoints.MapEndpoints(app, spotify);

app.Run();
