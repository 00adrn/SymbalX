using SpotifyAPI.Web;
namespace SpotifyTrackerApp.SpotifyControls;

public class SpotifyAuth
{
    private string? _clientID;
    private string? _verifier;
    private PKCETokenResponse? _initialResponse;

    public SpotifyAuth()
    {
        _clientID = File.ReadAllLines("client.txt")[0];
    }


    public Uri GenerateLoginUri()
    {
        var (verifier, challenge) = PKCEUtil.GenerateCodes();
        _verifier = verifier;

        SpotifyAPI.Web.LoginRequest loginRequest = new(new Uri("http://[::1]:5157/callback"),
            _clientID!,
            SpotifyAPI.Web.LoginRequest.ResponseType.Code)
        {
            CodeChallengeMethod = "S256",
            CodeChallenge = challenge,
            Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative}
        };

        return loginRequest.ToUri();
    }

    public async Task<PKCETokenResponse> GetCallBack(string code)
    {
        _initialResponse = await new OAuthClient().RequestToken(
            new PKCETokenRequest(_clientID!, code, new Uri("http://[::1]:5157/callback"), _verifier!)
        );

        return _initialResponse;
    }

    public async Task RefreshPKCEToken(Spotify spotify)
    {
        PKCETokenResponse newResponse = await new OAuthClient().RequestToken(
            new PKCETokenRefreshRequest(_clientID!, _initialResponse!.RefreshToken)
        );

        _initialResponse = newResponse;
        spotify.RefreshToken(newResponse.AccessToken);
    }
}
