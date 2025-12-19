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
        string? accessToken = http.HttpContext?.Session.GetString("accessToken");
        if (accessToken != null)
            spotify = new(accessToken);
        else
            spotify = null;
    }
    public async Task<Track> GetCurrentTrackAsync()
    {
        if (spotify is null)
            return new Track();

        var resp = await spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest());
        Track res = new Track();
        if (resp.Item is FullTrack track) 
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
}
