using SpotifyAPI.Web;

namespace backend.src.dtos;

public class Album
{
    public string spotifyUri {get; set;}
    public string name {get; set;}
    public string imageUrl {get; set;}
    public List<Artist> artists {get; set;}
    public List<Track> tracks {get; set;}


    public Album()
    {
        spotifyUri = "null";
        name = "null";
        imageUrl = "null";
        artists = new List<Artist>();
        tracks = new List<Track>();
    }
    public Album(FullAlbum album)
    {
        spotifyUri = album.Uri;
        name = album.Name;
        imageUrl = album.Images[0].Url;
        artists = new List<Artist>();
        foreach (var artist in album.Artists)
            artists.Add(new Artist(artist));
        tracks = new List<Track>();
        foreach (var track in album.Tracks.Items!)
            tracks.Add(new Track(track));
    }
}

