using SpotifyAPI.Web;
using dotenv.net;
namespace SpotifyTrackerApp.SpotifyControls;


public class SpotifyAuth
{
    private string? _clientID;
    private string? _verifier;
    private string rootAddress;

    public SpotifyAuth()
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();
        _clientID = envVars["CLIENT_ID"];
        rootAddress = envVars["API"];
    }


    public Uri GenerateLoginUri()
    {
        var (verifier, challenge) = PKCEUtil.GenerateCodes();
        _verifier = verifier;

        SpotifyAPI.Web.LoginRequest loginRequest = new(new Uri($"{rootAddress}/callback"),
            _clientID!,
            SpotifyAPI.Web.LoginRequest.ResponseType.Code)
        {
            CodeChallengeMethod = "S256",
            CodeChallenge = challenge,
            Scope = new[] { Scopes.PlaylistReadPrivate,
                            Scopes.PlaylistReadCollaborative,
                            Scopes.UserReadCurrentlyPlaying,
                            Scopes.UserFollowRead,
                            Scopes.UserReadPlaybackState,
                            Scopes.UserReadRecentlyPlayed,
                            Scopes.UserTopRead,
                            Scopes.UserReadPrivate }
        };

        return loginRequest.ToUri();
    }

    public async Task<PKCETokenResponse> GetCallBack(string code)
    {
        PKCETokenResponse response = await new OAuthClient().RequestToken(
            new PKCETokenRequest(_clientID!, code, new Uri($"{rootAddress}/callback"), _verifier!)
        );

        return response;
    }

    public async Task<PKCETokenResponse> RefreshPKCEToken(string refreshToken)
    {
        PKCETokenResponse newResponse = await new OAuthClient().RequestToken(
            new PKCETokenRefreshRequest(_clientID!, refreshToken)
        );

        return newResponse;
    }
}
