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

        group.MapGet("/validate", async (HttpContext context) =>
        {
 
            if (context.Request.Cookies[AccessTokenKey] is not null)
            {
                string token = context.Request.Cookies[AccessTokenKey]!;
                if (token is null || token == String.Empty)
                {
                    Console.WriteLine("Validation Error: Authentication cookie read as null or empty\n");
                    return Results.Unauthorized();
                }
                try
                {
                    Spotify spotify = new(token);
                    var testTrack = await spotify.GetTrackInfoAsync("2eIcjpotUGm07AaySZyaD6");
                }
                catch (Exception e)
                {
                    await CookieRefresher.RefreshTokenCookies(context);
                }
                Console.WriteLine($"Validation Success: Cookie read successfully\n");
                return Results.Ok();
            }
            Console.WriteLine("Validation Error: Authentication Cookie Not Found\n");
            return Results.Unauthorized();
        });

        group.MapGet("/login", (SpotifyAuth spotifyAuthenticator) =>
        {
            var loginUri = spotifyAuthenticator.GenerateLoginUri();
            return Results.Redirect(loginUri.ToString());
        });

        app.MapGet("/callback", async (string code, SpotifyAuth spotifyAuthenticator, HttpContext context) =>
        {
            PKCETokenResponse responseToken = await spotifyAuthenticator.GetCallBack(code);

            if (responseToken is not null)
            {
                CookieRefresher.AddCookies(responseToken, context);
                return Results.Redirect("http://localhost:5173");
            }

            return Results.NotFound();
        });

        return group;
    }

}

public static class CookieRefresher
{
    public const string AccessTokenKey = "spf-access-token";
    public const string RefreshTokenKey = "spf-refresh-token";
    public static async Task RefreshTokenCookies(HttpContext context)
    {
        SpotifyAuth authenticator = new();

        context.Response.Cookies.Delete(AccessTokenKey);
        context.Response.Cookies.Delete(RefreshTokenKey);

        Console.WriteLine("attempting to refresh");

        AddCookies(await authenticator.RefreshPKCEToken(context.Request.Cookies[RefreshTokenKey]!), context);
    }

    public static void AddCookies(PKCETokenResponse responseToken, HttpContext context)
    {
        context.Response.Cookies.Append(AccessTokenKey, responseToken.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Domain = "[::1]"
        });
        context.Response.Cookies.Append(RefreshTokenKey, responseToken.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Domain = "[::1]"
        });

        Console.WriteLine($"Cookies Refreshed\nNew Access Token: {responseToken.AccessToken}\n\nNew Refresh Token: {responseToken.RefreshToken}\n");
        }
}
