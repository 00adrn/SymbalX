using SpotifyTrackerApp.SpotifyControls;
namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyAuthEndpoints
{
    public static RouteGroupBuilder MapEndpoints(this WebApplication app,Spotify spotify)
    {
        RouteGroupBuilder group = app.MapGroup("/auth");

        SpotifyAuth spotifyAuthenticator = new SpotifyAuth();

        group.MapGet("", () =>
        {
            if (spotify.IsAuthenticated())
                return Results.Redirect("http://localhost:5157/spotify");

            else Console.WriteLine("Spotify not connected!");
            return Results.Redirect("http://localhost:5157/auth/login");
        });

        group.MapGet("/login", () =>
        {
            Uri uri = spotifyAuthenticator.GenerateLoginUri();

            return Results.Redirect(uri.ToString());
        });

        app.MapGet("/callback", async (string code) =>
        {
            await spotifyAuthenticator.GetCallBack(code, spotify);

            return Results.Redirect("http://localhost:5157/spotify");
        });

        return group;
    }
}
