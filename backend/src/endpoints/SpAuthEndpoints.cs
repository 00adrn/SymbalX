using System;
using backend.src.spotify;

namespace backend.src.endpoints;

public static class MapSpAuthEndpoints
{
    public static RouteGroupBuilder MapSpAuth(this IEndpointRouteBuilder app, Dictionary<string, string> env)
    {
        var group = app.MapGroup("/auth");

        group.MapGet("/", (IHttpContextAccessor context) =>
        {
            string? verifer = context.HttpContext?.Session.GetString("verifier");
            if (String.IsNullOrEmpty(verifer))
                return Results.Redirect($"{env["backendUrl"]}/auth/login");

            return Results.Ok("Successfully logged in.");
        });

        group.MapGet("/login", (SpAuth auth) =>
        {
            Uri requestUri = auth.GenerateLoginUri();
            return Results.Redirect(requestUri.ToString());
        });

        group.MapGet("/callback", async (string code, SpAuth auth) =>
        {
            bool res = await auth.HandleCallback(code);
            if (res)
                return Results.Redirect($"{env["backendUrl"]}/auth");
            
            return Results.BadRequest();
        });

        return group;
    }
}
