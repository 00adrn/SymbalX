using System;
using Microsoft.AspNetCore.Identity.Data;
using SpotifyAPI.Web;

namespace SpotifyTrackerApp.Spotify;

public class Spotify
{
    private SpotifyClient? spotifyClient;
    private string? _clientID;
    private string? _verifier;


    public Spotify()
    {
        _clientID = File.ReadAllLines("client.txt")[0];
        Console.WriteLine(_clientID);
    }


    public Uri GenerateLoginUri()
    {
        var (verifier, challenge) = PKCEUtil.GenerateCodes();
        _verifier = verifier;

        SpotifyAPI.Web.LoginRequest loginRequest = new(new Uri("http://[::1]:5137/callback"),
            _clientID!,
            SpotifyAPI.Web.LoginRequest.ResponseType.Code)
        {
            CodeChallengeMethod = "S256",
            CodeChallenge = challenge,
            Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
        };

        return loginRequest.ToUri();
    }

    public async Task GetCallBack(string code)
    {
        PKCETokenResponse initialResponse = await new OAuthClient().RequestToken(
            new PKCETokenRequest(_clientID!, code, new Uri("http://[::1]:5137"), _verifier!)
        );

        spotifyClient = new (initialResponse.AccessToken);
    }
}
