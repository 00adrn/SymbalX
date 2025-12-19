using System.Text.Json.Nodes;
using backend.src.dtos;
using backend.src.spotify;

namespace backend.src.endpoints;

public static class SpApiEndpoints
{
    public static RouteGroupBuilder MapSpApiEndpoints(this IEndpointRouteBuilder app, Dictionary<string, string> env)
    {
        var group = app.MapGroup("/api");

        group.MapGet("/current-track", async (SpApi api) =>
        {
            Track track = await api.GetCurrentTrackAsync();
            return Results.Ok(track);
        });

        group.MapGet("/get-info", async (string uri, SpApi api) =>
        {
            //Spotify uris look like this: spotify:artist:somerandomcode
            //By just splicing the query it allows me to only make one endpoint.
            string[] splitUri = uri.Split(":");
            string type = splitUri[1];
            string id = splitUri[2];

            if (type == "track")
            {
                Track track = await api.GetTrackAsync(id);
                return Results.Ok(track);
            } 
            else if (type == "album")
            {
                Album album = await api.GetAlbumAsync(id);
                return Results.Ok(album);
            } 
            else if (type =="artist")
            {
                Artist artist = await api.GetArtistAsync(id);
                return Results.Ok(artist);
            }
            else if (type == "playlist")
            {
                Playlist playlist = await api.GetPlaylistAsync(id);
                return Results.Ok(playlist);
            }
            else 
                return Results.BadRequest();
        });

        return group;
    }
}
