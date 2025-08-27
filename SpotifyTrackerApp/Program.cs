using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SpotifyTrackerApp.SpotifyControls.Spotify>();
builder.Services.AddSingleton<SpotifyAuth>();
builder.Services.AddHttpContextAccessor();

const string devCorsPolicy = "devCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: devCorsPolicy, policy =>
    {
        policy.WithOrigins("http://[::1]:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseCors(devCorsPolicy);


SpotifyEndpoints.MapSpotifyEndpoints(app);
SpotifyAuthEndpoints.MapAuthEndpoints(app);


app.Run();

