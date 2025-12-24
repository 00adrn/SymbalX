using dotenv.net;
using backend.src.spotify;
using backend.src.endpoints;

DotEnv.Load();
var env = DotEnv.Read().ToDictionary();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SpAuth>();
builder.Services.AddScoped<SpApi>();
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
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "frontendpolicy", policy =>
    {
        policy.WithOrigins(env["FRONTENDURL"], env["BACKENDURL"])
              .AllowCredentials()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSession();
app.UseCors("frontendpolicy");

app.MapSpAuth(env);
app.MapSpApiEndpoints(env);

Console.WriteLine($"{env["BACKENDURL"]}/auth/login");
app.Run();
