using SpotifyAPI.Web;
using SpotifyTrackerApp.Endpoints;
namespace SpotifyTrackerApp.SpotifyControls;

public class Spotify
{
    private SpotifyClient? _spotifyClient;

    public bool IsAuthenticated => _spotifyClient is not null;

    public Spotify(IHttpContextAccessor contextAccessor)
    {
        HttpContext? context = contextAccessor.HttpContext;

        if (context!.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey] is not null)
            _spotifyClient = new SpotifyClient(context.Request.Cookies[SpotifyAuthEndpoints.AccessTokenKey]!);
        else
        {
            Console.WriteLine("Token was null");
        }
    }

    public void RefreshToken(string newToken)
    {
        _spotifyClient = new(newToken);
    }

    public async Task<FullPlaylist> GetPlaylistInfoAsync(string uri)
    {
        return await _spotifyClient!.Playlists.Get(uri);
    }

    public async Task<FullTrack> GetTrackInfoAsync(string uri)
    {
        return await _spotifyClient!.Tracks.Get(uri);
    }

    public async Task<FullAlbum> GetAlbumInfoAsync(string uri)
    {
        return await _spotifyClient!.Albums.Get(uri);
    }

    public async Task<FullArtist> GetArtistInfoAsync(string uri)
    {
        return await _spotifyClient!.Artists.Get(uri);
    }
}
