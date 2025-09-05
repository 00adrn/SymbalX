using SpotifyAPI.Web;
using SpotifyTrackerApp.Dtos;
namespace SpotifyTrackerApp.SpotifyControls;

public class Spotify
{
    private SpotifyClient? _spotifyClient;

    public bool IsAuthenticated
    {
        get
        {
            return _spotifyClient is not null;
        }
    }

    public Spotify(string token)
    {
        _spotifyClient = new SpotifyClient(token);
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

    public async Task<TrackDto?> GetCurrentTrackInfoAsync()
    {
        CurrentlyPlaying currentlyPlaying = await _spotifyClient!.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest());
        var trackItem = currentlyPlaying.Item;
        if (trackItem is FullTrack track1) return new TrackDto(track1);
        return null;
    }

    public async Task<ProfileDto?> GetProfileInfoAsync()
    {
        PrivateUser profile = await _spotifyClient!.UserProfile.Current();
        return profile is not null ? new ProfileDto(profile) : null;
    }

    public async Task<List<SimplePlaylistDto>?> GetAllPlaylistsAsync()
    {
        PrivateUser? user = await _spotifyClient!.UserProfile.Current();
        string userId = user.Id;
        var playlists = await _spotifyClient!.Playlists.GetUsers(userId);
        return playlists is not null ? playlists.Items!.Select(playlist => new SimplePlaylistDto(playlist)).ToList() : null;
    }
    
}
