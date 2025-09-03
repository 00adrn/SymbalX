using SpotifyTrackerApp.Dtos;
using SpotifyTrackerApp.SpotifyControls;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyEndpoints
{
    
    
    public static RouteGroupBuilder MapSpotifyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");

        group.MapGet("/user-info", async (HttpContext context) =>
        {
            string token = context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!;

            Console.WriteLine($"GET /user-info");

            if (token == null || token == string.Empty)
            {
                Console.WriteLine($"Token read error\n");
                return Results.Ok();
            }

            Spotify spotify = new(token);

            ProfileDto?  profile = await spotify.GetProfileInfoAsync();
            return Results.Ok(profile);
        }); 

        group.MapGet("/spotify:{type}:{uri}", async (string type, string uri, HttpContext context) =>
        {

            string token = context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!;

            Console.WriteLine($"GET /{type} /{uri}");

            if (token == null || token == string.Empty)
            {
                Console.WriteLine($"Token read error\n");
                return Results.Ok();
            }

            Spotify spotify = new(token);

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

        group.MapGet("current-track", async (HttpContext context) =>
        {
            try
            {
                string token = context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!;

                Console.WriteLine($"GET /current-track");

                if (token == null || token == string.Empty)
                {
                    Console.WriteLine($"Token read error\n");
                    return Results.Ok();
                }

                Spotify spotify = new(token);

                TrackDto? track = await spotify.GetCurrentTrackInfoAsync();
                if (track == null)
                {
                    return Results.Ok("No current Track");
                }
                return Results.Ok(track);
            }
            catch
            {
                FullTrack? track = null;
                return Results.Ok(new TrackDto(track));
            }
        });

        return group;
    }
}
