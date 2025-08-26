using SpotifyAPI.Web;
using SpotifyTrackerApp.SpotifyControls;
namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyAuthEndpoints
{
    public const string AccessTokenKey = "spf-access-token";

    public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/auth");

        group.MapGet("", (HttpContext context) =>
        {
            if (context.Request.Cookies.ContainsKey(AccessTokenKey))
                return Results.Redirect("http://localhost:5157/spotify");

            return Results.Redirect("http://localhost:5157/auth/login");
        });

        group.MapGet("/login", (SpotifyAuth spotifyAuthenticator) =>
        {
            var uri = spotifyAuthenticator.GenerateLoginUri();
            return Results.Redirect(uri.ToString());
        });

        app.MapGet("/callback", async (string code, SpotifyAuth spotifyAuthenticator, HttpContext context) =>
        {
            PKCETokenResponse responseToken = await spotifyAuthenticator.GetCallBack(code);

            if (responseToken is not null)
            {
                context.Response.Cookies.Append(AccessTokenKey, responseToken.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTime.UtcNow.AddSeconds(responseToken.ExpiresIn)
                });
            }

            return Results.Redirect("http://localhost:5157/spotify");
        });

        return group;
    }
}
