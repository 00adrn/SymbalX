using SpotifyAPI.Web;
using dotenv.net;

namespace backend.src.spotify;

public class SpAuth
{
    private string _clientId;
    private string _backendUrl;
    private string _verifier = "";
    public SpAuth()
    {
        DotEnv.Load();
        var env = DotEnv.Read();
        _clientId = env["clientId"];
        _backendUrl = env["backendUrl"];
    }
    public IResult RedirectToLogin()
    {
        var (verifier, challenge) = PKCEUtil.GenerateCodes();
        _verifier = verifier;
        LoginRequest request = new LoginRequest(new Uri($"{_backendUrl}/auth/callback"), _clientId, LoginRequest.ResponseType.Code)
        {
            CodeChallengeMethod = "S256",
            CodeChallenge = challenge,
            Scope = new[] { Scopes.PlaylistReadPrivate,
                            Scopes.PlaylistReadCollaborative,
                            Scopes.UserReadCurrentlyPlaying,
                            Scopes.UserFollowRead,
                            Scopes.UserReadPrivate }
        };
        Uri redirectUri =  request.ToUri();
        return Results.Redirect(redirectUri.ToString());
    }
    
    public async Task<PKCETokenResponse> HandleCallback (string responseCode)
    {
        var response = await new OAuthClient().RequestToken(
            new PKCETokenRequest(_clientId, responseCode, new Uri($"{_backendUrl}/auth/callback"), _verifier)
        );
        return response;
    }

}
