using dotenv.net;
using backend.src.spotify;

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

    

    Console.WriteLine($"{env["backendUrl"]}/auth/login");
    app.Run();
