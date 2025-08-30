using SpotifyAPI.Web;
using SpotifyTrackerApp.Endpoints;
using SpotifyTrackerApp.Dtos;
namespace SpotifyTrackerApp.SpotifyControls;

public class Spotify
{
    private SpotifyClient? _spotifyClient;

    public bool IsAuthenticated => _spotifyClient is not null;

    public Spotify(string token)
    {
        _spotifyClient = new SpotifyClient(token);

    }

    public void RefreshToken(string newToken)
    {
        _spotifyClient = new(newToken);
    }

    public async Task<PlaylistDto?> GetPlaylistInfoAsync(string uri)
    {
        FullPlaylist? playlist = await _spotifyClient!.Playlists.Get(uri);
        return playlist is not null ? new PlaylistDto(playlist) : null;
    }

    public async Task<TrackDto?> GetTrackInfoAsync(string uri)
    {
        FullTrack? track = await _spotifyClient!.Tracks.Get(uri);
        return track is not null ? new TrackDto(track) : null;
    }

    public async Task<AlbumDto?> GetAlbumInfoAsync(string uri)
    {
        FullAlbum? album = await _spotifyClient!.Albums.Get(uri);
        return album is not null ? new AlbumDto(album) : null;
    }

    public async Task<ArtistDto?> GetArtistInfoAsync(string uri)
    {
        FullArtist? artist = await _spotifyClient!.Artists.Get(uri);
        return artist is not null ? new ArtistDto(artist) : null;
    }
}
