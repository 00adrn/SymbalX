using SpotifyTrackerApp.Dtos;
using SpotifyTrackerApp.SpotifyControls;

namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyEndpoints
{
    public static RouteGroupBuilder MapSpotifyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");

        group.MapGet("/spotify:{type}:{uri}", async (string type, string uri, HttpContext context) =>
        {

            Spotify spotify = new(context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!);

            Console.WriteLine($"GET /{type} /{uri}");

            if (!spotify.IsAuthenticated)
            {
                Console.WriteLine("Unauthorized Request\n");
                return Results.Unauthorized();
            }
            else
                Console.WriteLine("Authorized Request\n");

            switch (type)
                {
                    case "playlist":
                        PlaylistDto? playlist = await spotify.GetPlaylistInfoAsync(uri);
                        return Results.Ok(playlist);

                    case "track":
                        TrackDto? track = await spotify.GetTrackInfoAsync(uri);
                        return Results.Ok(track);

                    case "album":
                        AlbumDto? album = await spotify.GetAlbumInfoAsync(uri);
                        return Results.Ok(album);

                    case "artist":
                        ArtistDto? artist = await spotify.GetArtistInfoAsync(uri);
                        return Results.Ok(artist);

                    default:
                        return Results.NotFound();

                }                
        });

        return group;
    }
}
