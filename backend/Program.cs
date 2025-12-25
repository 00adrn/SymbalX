using dotenv.net;
using backend.src.spotify;
using backend.src.endpoints;
using System.Net;
using Microsoft.Extensions.Options;

DotEnv.Load();
var env = DotEnv.Read().ToDictionary();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SpApi>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowFrontend", policy =>
    {
        policy.WithOrigins(env["FRONTENDURL"], env["BACKENDURL"])
              .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("allowFrontend");

app.MapSpApiEndpoints(env);

app.Run();
