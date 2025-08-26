using SpotifyAPI.Web;
using SpotifyTrackerApp.Dtos;
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
            FullPlaylist playlist = await spotify.GetPlaylistInfoAsync(uri);

            return Results.Ok(new PlaylsitDto(playlist));
        });

        group.MapGet("/track/{uri}", async (string uri) =>
        {
            FullTrack track = await spotify.GetTrackInfoAsync(uri);

            return Results.Ok(new TrackDto(track));
        });

        group.MapGet("/album/{uri}", async (string uri) =>
        {
            FullAlbum album = await spotify.GetAlbumInfoAsync(uri);

            return Results.Ok(new AlbumDto(album));
        });

        group.MapGet("/artist/{uri}", async (string uri) =>
        {
            FullArtist artist = await spotify.GetArtistInfoAsync(uri);

            return Results.Ok(new ArtistDto(artist));
        });

        return group;
    }
}
