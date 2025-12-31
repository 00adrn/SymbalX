using System;
using SpotifyAPI.Web;
using backend.src.dtos;
using System.Reflection.Metadata.Ecma335;
namespace backend.src.spotify;

public class SpApi
{
    private SpotifyClient? spotify = null;
    public SpApi(IHttpContextAccessor http)
    {
        string? accessToken = http.HttpContext?.Request.Headers.Authorization.ToString().Split(" ")[1];

        if (accessToken != null)  {
            spotify = new(accessToken);
            Console.WriteLine("Spotify object successfully instantiated.");
        }
        else {
            spotify = null;
            Console.WriteLine("Spotify object failed to instantiate.");
        }
    }
    public async Task<Track> GetCurrentTrackAsync()
    {
        if (spotify is null)
            return new Track();

        var resp = await spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest());
        Track res = new Track();
        if (resp is not null && resp.Item is FullTrack track) 
            res = new Track(track);
        
        return res;
    }
    public async Task<Track> GetTrackAsync(string uri)
    {
        if (spotify is null)
            return new Track();
        
        var resp = await spotify.Tracks.Get(uri);
        return resp is null ? new Track() : new Track(resp);
    }
    public async Task<Album> GetAlbumAsync(string uri)
    {
        if (spotify is null)
            return new Album();
        
        var resp = await spotify.Albums.Get(uri);
        return resp is null ? new Album() : new Album(resp);
    }

    public async Task<Artist> GetArtistAsync(string uri)
    {
        if (spotify is null)
            return new Artist();

        var resp = await spotify.Artists.Get(uri);
        return resp is null ? new Artist() : new Artist(resp);
    }

    public async Task<Playlist> GetPlaylistAsync(string uri)
    {
        if (spotify is null)
            return new Playlist();

        var resp = await spotify.Playlists.Get(uri);
        return resp is null ? new Playlist() : new Playlist(resp);
    }

    public async Task<Profile> GetProfileInfoAsync()
    {
        if (spotify is null)
            return new Profile();

        var resp = await spotify.UserProfile.Current();
        return resp is null ? new Profile() : new Profile(resp);
    }

    public async Task<List<Playlist>> GetAllPlaylistsAsync()
    {
        if (spotify is null)
            return new List<Playlist>();
            
        var profile = await spotify.UserProfile.Current();
        string userId = profile.Id;

        var playlists = await spotify.Playlists.GetUsers(userId);
        return playlists is null ? new List<Playlist>() : playlists.Items!.Select(playlist => new Playlist(playlist, false)).ToList(); 
    }
}
