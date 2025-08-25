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

    public async Task<FullPlaylist> GetPaylistInfoAsync(string uri)
    {
        return await spotifyClient!.Playlists.Get(uri);
    }

    public async Task<FullTrack> GetTrackInfoAsync(string uri)
    {
        return await spotifyClient!.Tracks.Get(uri);
    }

    public async Task<FullAlbum> GetAlbumInfoAsync(string uri)
    {
        return await spotifyClient!.Albums.Get(uri);
    }

    public async Task<FullArtist> GetArtistInfoAsync(string uri)
    {
        return await spotifyClient!.Artists.Get(uri);
    }
}
