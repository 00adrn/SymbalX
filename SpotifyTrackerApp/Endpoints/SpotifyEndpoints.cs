using SpotifyAPI.Web;
using SpotifyTrackerApp.SpotifyControls;
namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyEndpoints
{
    public static RouteGroupBuilder MapEndpoints(this WebApplication app, Spotify spotify)
    {
        RouteGroupBuilder group = app.MapGroup("/spotify");

        group.MapGet("", () =>
        {
            return "Spotify Page";
        });

        group.MapGet("/playlists/{uri}", async (string uri) =>
        {
            FullPlaylist playlist = await spotify.GetPaylistInfo(uri);

            return Results.Ok(playlist);
        });

        return group;
    }
}
