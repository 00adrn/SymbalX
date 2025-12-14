    using dotenv.net;
    using backend.src.spotify;

    DotEnv.Load();
    var env = DotEnv.Read();

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddScoped<SpAuth>();
    builder.Services.AddHttpContextAccessor();
    var app = builder.Build();

    app.MapGet("/auth/login", (SpAuth auth) =>
    {
        return auth.RedirectToLogin();
    });
    app.MapGet("/auth/callback", async (string code, SpAuth auth) =>
    {
        await auth.HandleCallback(code);
        return Results.Ok();
    });

    app.Run();
