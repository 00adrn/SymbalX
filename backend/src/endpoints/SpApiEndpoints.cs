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
            Console.WriteLine("Endpoint hit on backend: /api/current-track");
            Track track = await api.GetCurrentTrackAsync();
            return Results.Ok(track);
        });

        group.MapGet("/get-info", async (string uri, SpApi api) =>
        {
            string[] splitUri = uri.Split(":");
            string type = splitUri[1];
            string id = splitUri[2];

            Console.Write("Endpoint hit on backend: /api/get-info-");

            if (type == "track")
            {
                Console.WriteLine("track");
                Track track = await api.GetTrackAsync(id);
                return Results.Ok(track);
            } 
            else if (type == "album")
            {
                Console.WriteLine("album");
                Album album = await api.GetAlbumAsync(id);
                return Results.Ok(album);
            } 
            else if (type =="artist")
            {
                Console.WriteLine("artist");
                Artist artist = await api.GetArtistAsync(id);
                return Results.Ok(artist);
            }
            else if (type == "playlist")
            {
                Console.WriteLine("playlist");
                Playlist playlist = await api.GetPlaylistAsync(id);
                return Results.Ok(playlist);
            }
            else 
                return Results.BadRequest();
        });

        return group;
    }
}
