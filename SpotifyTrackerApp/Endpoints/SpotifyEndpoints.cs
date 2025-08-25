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

        group.MapGet("/playlist/{uri}", async (string uri) =>
        {
            FullPlaylist playlist = await spotify.GetPaylistInfoAsync(uri);

            return Results.Ok(playlist);
        });

        group.MapGet("/track/{uri}", async (string uri) =>
        {
            FullTrack track = await spotify.GetTrackInfoAsync(uri);

            return Results.Ok(track);
        });

        group.MapGet("/album/{uri}", async (string uri) =>
        {
            FullAlbum album = await spotify.GetAlbumInfoAsync(uri);

            return Results.Ok(album);
        });

        group.MapGet("/artist/{uri}", async (string uri) =>
        {
            FullArtist artist = await spotify.GetArtistInfoAsync(uri);

            return Results.Ok(artist);
        });

        return group;
    }
}
