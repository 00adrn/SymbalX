using System;
using backend.src.spotify;

namespace backend.src.endpoints;

public static class MapSpAuthEndpoints
{
    public static RouteGroupBuilder MapSpAuth(this IEndpointRouteBuilder app, IDictionary<string, string> env)
    {
        var group = app.MapGroup("/auth");


        app.MapGet("/", (IHttpContextAccessor context) =>
        {
            string? verifer = context.HttpContext?.Session.GetString("verifier");
            if (String.IsNullOrEmpty(verifer))
                return Results.Redirect($"{env["backendUrl"]}/auth/login");
            return Results.Ok();
        });

        app.MapGet("/login", (SpAuth auth) =>
        {
            Uri requestUri = auth.RedirectToLogin();
            return Results.Redirect(requestUri.ToString());
        });

        app.MapGet("/callback", async (string code, SpAuth auth) =>
        {
            bool res = await auth.HandleCallback(code);
            if (res)
                return Results.Ok();
            return Results.BadRequest();
        });

        return group;
    }
}
