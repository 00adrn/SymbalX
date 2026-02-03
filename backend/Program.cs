using dotenv.net;
using backend.src.spotify;
using backend.src.worker;
using Microsoft.Extensions.DependencyInjection;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<TokenRefreshWorker>();

var app = builder.Build();

app.Run();
