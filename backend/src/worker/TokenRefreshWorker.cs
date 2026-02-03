using System;
using Supabase;
using Microsoft.Extensions.Hosting; 
using Microsoft.Extensions.Logging; 
using System.Threading.Tasks;
using backend.src.dbModels;
using backend.src.spotify;

namespace backend.src.worker;

public class TokenRefreshWorker : BackgroundService
{
    private readonly ILogger<TokenRefreshWorker> _logger;
    private Supabase.Client? _supabase = null;
    private SpAuth _auth;

    public TokenRefreshWorker (ILogger<TokenRefreshWorker> logger)
    {
        _logger = logger;

        string? url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        string? key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

        _auth = new SpAuth();

        var options =  new Supabase.SupabaseOptions { AutoConnectRealtime = true };

        if (url is not null && key is not null) {
            _supabase = new Supabase.Client(url, key, options);
            _logger.LogInformation("Supabase Client successfully created");
            return;
        }
        _logger.LogError("ERROR: Supabase Client failed to initialize, environment variables nulled.");
    }


    protected override async Task ExecuteAsync (CancellationToken stopToken)
    {
        if (_supabase is null)
        {
            _logger.LogInformation("Supabase client is null.");
            return;
        }
        
        await _supabase.InitializeAsync();

        while (!stopToken.IsCancellationRequested)
        {
            _logger.LogInformation("Token Refresh Worker running at: {time}", DateTimeOffset.Now);

            var userData = await _supabase.From<UserProfileInfo>().Get();

            foreach (var user in userData.Models)
            {
                Console.WriteLine($"User: {user.Username}");

                if(user.SpAccessToken is null || user.SpRefreshToken is null)
                {
                    Console.WriteLine("User has null tokens.");
                    continue;
                }
                var tokens = await _auth.RefreshAccessTokenAsync(user.SpRefreshToken);

                user.SpAccessToken = tokens.accessToken;
                if (tokens.refreshToken is not null)
                    user.SpRefreshToken = tokens.refreshToken;
                await user.Update<UserProfileInfo>();

                _logger.LogInformation($"User <{user.Username}> tokens refreshed");
            }

            await Task.Delay(1800000, stopToken);
        }

        _logger.LogInformation("Token Refresh Worker stopped.");
    }


}
