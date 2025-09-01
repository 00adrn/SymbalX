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
            if (context.Request.Cookies[AccessTokenKey] is not null)
            {
                string token = context.Request.Cookies[AccessTokenKey]!;
                if (token is null || token == String.Empty)
                {
                    Console.WriteLine("Validation Error: Authentication cookie read as null or empty\n");
                    return Results.Unauthorized();
                }
                Console.WriteLine($"Validation Success: Cookie read successfully\n");
                return Results.Ok();
            }
            Console.WriteLine("Validation Error: Authentication Cookie Not Found\n");
            return Results.Unauthorized();
        });

        group.MapGet("", (HttpContext context) =>
        {

            if (context.Request.Cookies[AccessTokenKey] is not null && context.Request.Cookies[RefreshTokenKey] is not null)
            {
                return Results.Redirect("http://localhost:5173");
            }

            return Results.Redirect("http://[::1]:5157/auth/login");
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

        group.MapGet("/refresh-login:{origin}", async (HttpContext context, SpotifyAuth authenticator, string origin) =>
        {
            context.Response.Cookies.Delete(AccessTokenKey);
            context.Response.Cookies.Delete(RefreshTokenKey);

            CookieRefresher.AddCookies(await authenticator.RefreshPKCEToken(context.Request.Cookies[RefreshTokenKey]!), context);

            return Results.Redirect(origin);
        });

        group.MapGet("/home", (HttpContext context, SpotifyAuth authenticator) =>
        {
            return Results.Ok("home page");
        });

        group.MapGet("refresh-token", async (HttpContext context) =>
        {
            CookieRefresher.RefreshTokenCookies(context);
            return Results.Redirect("http://localhost:5173");
        });

        return group;
    }

}

public static class CookieRefresher
{
    public const string AccessTokenKey = "spf-access-token";
    public const string RefreshTokenKey = "spf-refresh-token";
    public static async void RefreshTokenCookies(HttpContext context)
    {
        SpotifyAuth authenticator = new();

        context.Response.Cookies.Delete(AccessTokenKey);
        context.Response.Cookies.Delete(RefreshTokenKey);

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
