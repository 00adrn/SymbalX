using SpotifyAPI.Web;
using Swan;
using Swan.Formatters;
namespace SpotifyTrackerApp.SpotifyControls;

public class Spotify
{
    public SpotifyClient? spotifyClient;


    public bool IsAuthenticated()
    {
        if (spotifyClient != null)
            return true;
        return false;
    }

    public async Task<FullPlaylist> GetPaylistInfo(string uri)
    {
        return await spotifyClient!.Playlists.Get(uri);
    }
}
