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
            Track track = await api.GetCurrentTrack();
            return Results.Ok(track);
        });

        group.MapGet("/get-info", async (string uri, SpApi api) =>
        {
            string[] splitUri = uri.Split(":");
            string type = splitUri[1];
            string id = splitUri[2];

            if (type == "track")
            {
                Track track = await api.GetTrackInfo(id);
                return Results.Ok(track);
            } else if (type == "album")
            {
                Album album = await api.GetAlbumInfo(id);
                return Results.Ok(album);
            } 
            else 
                return Results.BadRequest();
        });

        return group;
    }
}
