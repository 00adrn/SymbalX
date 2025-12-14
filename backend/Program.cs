    using dotenv.net;
    using backend.src.spotify;
using Microsoft.Extensions.Options;

DotEnv.Load();
    var env = DotEnv.Read();

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddScoped<SpAuth>();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(1);
        options.Cookie.Name = "sessionId";
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    var app = builder.Build();

    app.UseSession();

    app.MapGet("/", (IHttpContextAccessor context) =>
    {
        string? code = context.HttpContext?.Session.GetString("verifier");
        return Results.Ok(code);
    });
    app.MapGet("/auth/login", (SpAuth auth) =>
    {
        return auth.RedirectToLogin();
    });
    app.MapGet("/auth/callback", async (string code, SpAuth auth) =>
    {
        await auth.HandleCallback(code);
        return Results.Ok();
    });
    Console.WriteLine($"{env["backendUrl"]}/auth/login");
    app.Run();
