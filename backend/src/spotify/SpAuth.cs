using dotenv.net;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace backend.src.spotify;

public class SpAuth
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly HttpClient _http = new();
    private readonly string _spotifyUrl;

    public SpAuth()
    {
        _clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENTID")!;
        _spotifyUrl = Environment.GetEnvironmentVariable("SPOTIFY_API")!;
        _clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_CLIENTSECRET")!;
    }

    public async Task<(string accessToken, string? refreshToken)> RefreshAccessTokenAsync(string refreshToken)
    {
        var payload = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken),
            new KeyValuePair<string, string>("client_id", _clientId),
            new KeyValuePair<string, string>("client_secret", _clientSecret)
        });

        var resp = await _http.PostAsync(_spotifyUrl, payload);

        try{
            resp.EnsureSuccessStatusCode();

            string body = await resp.Content.ReadAsStringAsync();

            RefreshResponse refreshResponse = JsonSerializer.Deserialize<RefreshResponse>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return (refreshResponse.Access_Token!, refreshResponse.Refresh_Token);
        } catch
        {
            Console.WriteLine("Token Refresh Failed.");
            Console.WriteLine(await resp.Content.ReadAsStringAsync());
            return ("", "");
        }
    }
}

public record class RefreshResponse
{
    public string? Access_Token { get; set; }
    public string? Refresh_Token { get; set; }
}
