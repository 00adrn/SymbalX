using SpotifyAPI.Web;
using SpotifyTrackerApp.Dtos;
using SpotifyTrackerApp.SpotifyControls;
namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyEndpoints
{
    public static RouteGroupBuilder MapSpotifyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");

        group.MapGet("", (Spotify spotify) =>
        {
            if (spotify.IsAuthenticated)
                return "Spotify Authenticated";
            return "Error in spotify authentication";
        });

        group.MapGet("/spotify:playlist:{uri}", async (string uri, Spotify spotify) =>
        {
            FullPlaylist playlist = await spotify.GetPlaylistInfoAsync(uri);

            return Results.Ok(new PlaylsitDto(playlist));
        });

        group.MapGet("/spotify:track:{uri}", async (string uri, Spotify spotify) =>
        {
            FullTrack track = await spotify.GetTrackInfoAsync(uri);

            return Results.Ok(new TrackDto(track));
        });

        group.MapGet("/spotify:album:{uri}", async (string uri, Spotify spotify) =>
        {       
            FullAlbum album = await spotify.GetAlbumInfoAsync(uri);

            return Results.Ok(new AlbumDto(album));
        });

        group.MapGet("/spotify:artist:{uri}", async (string uri, Spotify spotify) =>
        {
            FullArtist artist = await spotify.GetArtistInfoAsync(uri);

            return Results.Ok(new ArtistDto(artist));
        });

        return group;
    }
}
