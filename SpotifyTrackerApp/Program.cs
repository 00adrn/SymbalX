using SpotifyTrackerApp;
using SpotifyTrackerApp.Spotify;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Spotify spotify = new Spotify();

app.MapGet("/spotify/login", () =>
{
    Uri uri = spotify.GenerateLoginUri();

    return Results.Redirect(uri.ToString());
});

app.Run();
