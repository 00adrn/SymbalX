using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SpotifyAuth>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors();


SpotifyEndpoints.MapSpotifyEndpoints(app);
SpotifyAuthEndpoints.MapAuthEndpoints(app);


Console.WriteLine("SERVER HOSTED ON http://[::1]:5157");

app.Run();

