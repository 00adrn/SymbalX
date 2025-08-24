using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Spotify spotify = new Spotify();

app.MapGet("", () => { return "main page"; });

SpotifyEndpoints.MapEndpoints(app, spotify);
SpotifyAuthEndpoints.MapEndpoints(app, spotify);

app.Run();
