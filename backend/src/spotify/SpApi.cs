using System;
using SpotifyAPI.Web;
using backend.src.dtos;
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
    
    public async Task<Track> GetCurrentTrack()
    {
        if (spotify is null)
            return new Track();

        var resp = await spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest());
        Track res = new Track();
        if (resp.Item is FullTrack track) 
            res = new Track(track);

        return res;
    }

    public async Task<Track> GetTrackInfo(string uri)
    {
        if (spotify is null)
            return new Track();
        
        var resp = await spotify.Tracks.Get(uri);
        Track res = new Track();
        if (resp is FullTrack track)
            res = new Track(track);

        return res;
    }

    public async Task<Album> GetAlbumInfo(string uri)
    {
        if (spotify is null)
            return new Album();
        
        var resp = await spotify.Albums.Get(uri);
        Album res = new Album();
        if (resp is FullAlbum album)
            res = new Album(album);

        return res;
    }
}
