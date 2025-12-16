using SpotifyAPI.Web;
using dotenv.net;

namespace backend.src.spotify;

public class SpAuth 
{
    private readonly string _clientId;
    private readonly string _backendUrl;
    private readonly IHttpContextAccessor _context;
    public SpAuth(IHttpContextAccessor http)
    {
        DotEnv.Load();
        var env = DotEnv.Read();
        _clientId = env["clientId"];
        _backendUrl = env["backendUrl"];
        _context = http;
    }
    public Uri RedirectToLogin()
    {
        var (verifier, challenge) = PKCEUtil.GenerateCodes();
        _context.HttpContext?.Session.SetString("verifier", verifier);
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
        Uri redirectUri = request.ToUri();
        return redirectUri;
    }
    
    public async Task<bool> HandleCallback (string responseCode)
    {
        string? verifier = _context.HttpContext?.Session.GetString("verifier");
        if (String.IsNullOrEmpty(verifier))
            return false;
        var response = await new OAuthClient().RequestToken(
            new PKCETokenRequest(_clientId, responseCode, new Uri($"{_backendUrl}/auth/callback"), verifier)
        );
        return true;
    }

}
