using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.SpotifyControls;
using dotenv.net;

DotEnv.Load();
var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddSingleton<SpotifyAuth>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy( "Allow Frontend", policy =>
    {
        policy.WithOrigins(envVars["API_LOCAL"])
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors("Allow Frontend");

SpotifyEndpoints.MapSpotifyEndpoints(app, envVars);
SpotifyAuthEndpoints.MapAuthEndpoints(app, envVars);

Console.WriteLine("SERVER HOSTED ON " + envVars["API"]);

app.Run();

