using SpotifyAPI.Web;
using SpotifyTrackerApp.SpotifyControls;
namespace SpotifyTrackerApp.Endpoints;

public static class SpotifyAuthEndpoints
{
    public const string AccessTokenKey = "spf-access-token";
    public const string RefreshTokenKey = "spf-refresh-token";


    public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/auth");

        group.MapGet("/validate", (HttpContext context) =>
        {
            Spotify spotify = new(context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!);
            
            if (spotify.IsAuthenticated)
            {
                Console.WriteLine("Authenticated\n");
                return Results.Ok();
            }
            Console.WriteLine("Not Authenticated\n");
            return Results.NotFound();
        });

        group.MapGet("", async (HttpContext context, SpotifyAuth spotifyAuthenticator) =>
        {

            if (context.Request.Cookies[AccessTokenKey] is not null)
            {
                // PKCETokenResponse responseToken = await spotifyAuthenticator.RefreshPKCEToken(context.Request.Cookies[RefreshTokenKey]!);


                return Results.Redirect("http://[::1]:5173");
            }

            return Results.Redirect("http://[::1]:5157/auth/login");
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
                    Secure = context.Request.IsHttps,
                    SameSite = context.Request.IsHttps ? SameSiteMode.None : SameSiteMode.Lax,
                    Expires = DateTime.UtcNow.AddHours(1)
                });
                context.Response.Cookies.Append(RefreshTokenKey, responseToken.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = context.Request.IsHttps,
                    SameSite = context.Request.IsHttps ? SameSiteMode.None : SameSiteMode.Lax,
                    Expires = DateTime.UtcNow.AddHours(1)
                });
            }

            return Results.Redirect("http://localhost:5173");
        });

        return group;
    }
}
