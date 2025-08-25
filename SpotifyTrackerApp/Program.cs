using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Spotify spotify = new Spotify();

app.MapGet("", () => { return Results.Redirect("localhost:5157/auth"); });

SpotifyEndpoints.MapEndpoints(app, spotify);
SpotifyAuthEndpoints.MapEndpoints(app, spotify);

app.Run();
